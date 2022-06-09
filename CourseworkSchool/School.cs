using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CourseProject
{
    /// <summary>
    /// Класс формы основного окна приложения
    /// </summary>
    /// <remarks>
    /// Позволяет получить объекты для валидации полей
    /// </remarks>
    public partial class School : Form
    {
        private readonly Dictionary<string, bool> AddButtonsStates = new()
        {
            { "Ученики", true },
            { "Учителя", true },
            { "Классы", true },
            { "Предметы", true },
            { "Успеваемость", true }
        };

        private readonly Dictionary<string, bool> DeleteButtonsStates = new()
        {
            { "Ученики", false },
            { "Учителя", false },
            { "Классы", false },
            { "Предметы", false },
            { "Успеваемость", false }
        };

        private readonly Dictionary<string, IBindingList> NamedOriginSources = new()
        {
            { "Ученики", new ObservableCollection<Student>().ToBindingList() },
            { "Учителя", new ObservableCollection<Teacher>().ToBindingList() },
            { "Классы", new ObservableCollection<Class>().ToBindingList() },
            { "Предметы", new ObservableCollection<Subject>().ToBindingList() },
            { "Успеваемость", new ObservableCollection<Mark>().ToBindingList() }
        };

        private readonly ImmutableDictionary<string, DataGridView> NamedGridViews;

        private readonly ImmutableDictionary<string, HashSet<int>> NamedIdsSets = new Dictionary<string, HashSet<int>>
        {
            { "Ученики", new() },
            { "Учителя", new() },
            { "Классы", new() },
            { "Предметы", new() },
            { "Успеваемость", new() }
        }.ToImmutableDictionary();

        private SchoolDbContext schoolContext;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public School()
        {
            InitializeComponent();

            ClassIdCellValidation = (DataGridView gridView, DataGridViewCellValidatingEventArgs e)
                => GenericCellValidation(gridView, e, str => IsIdExisting(str, classesGridView));

            StudentIdCellValidation = (DataGridView gridView, DataGridViewCellValidatingEventArgs e)
                => GenericCellValidation(gridView, e, str => IsIdExisting(str, studentsGridView));

            TeacherIdCellValidation = (DataGridView gridView, DataGridViewCellValidatingEventArgs e)
                => GenericCellValidation(gridView, e, str => IsIdExisting(str, teachersGridView));

            SubjectIdCellValidation = (DataGridView gridView, DataGridViewCellValidatingEventArgs e)
                => GenericCellValidation(gridView, e, str => IsIdExisting(str, subjectsGridView));

            NamedGridViews = new Dictionary<string, DataGridView>
            {
                { "Ученики", studentsGridView },
                { "Учителя", teachersGridView },
                { "Классы", classesGridView },
                { "Предметы", subjectsGridView },
                { "Успеваемость", marksGridView }
            }.ToImmutableDictionary();
        }

        private delegate void CellValidator(DataGridView gridView, DataGridViewCellValidatingEventArgs e);

        /// <summary>
        /// Регулярное выражения для проверки строки на соответствие формату номеру класса
        /// </summary>
        /// <value>
        /// Позволяет получить объект регулярного выражения
        /// </value>
        public static Regex ClassRegex { get; } = new Regex(@"^(?:[1-9]|10|11)[А-Я]$", RegexOptions.Compiled);

        /// <summary>
        /// Предикат, позволяет проверить, является ли строка именем
        /// </summary>
        /// <value>
        /// Позволяет получить предикат
        /// </value>
        public static Regex NameRegex { get; } = new Regex(@"^[А-Яа-я]*$", RegexOptions.Compiled);

        /// <summary>
        /// Предикат, позволяет проверить, является ли строка оценкой
        /// </summary>
        /// <value>
        /// Позволяет получить предикат
        /// </value>
        public static Predicate<string> IsMarkLegit { get; } = str => int.TryParse(str, out int number) && number > 0 && number < 6;

        /// <summary>
        /// Предикат, позволяет проверить, является ли строка положительным числом
        /// </summary>
        /// <value>
        /// Позволяет получить предикат
        /// </value>
        public static Predicate<string> IsStringNonNegativeInt { get; } = str => int.TryParse(str, out int number) && number >= 0;

        private static CellValidator ClassCellValidation { get; } = (DataGridView gridView, DataGridViewCellValidatingEventArgs e)
            => GenericCellValidation(gridView, e, ClassRegex.IsMatch);
        private static CellValidator MarkCellValidation { get; } = (DataGridView gridView, DataGridViewCellValidatingEventArgs e)
            => GenericCellValidation(gridView, e, IsMarkLegit);
        private static CellValidator NameCellValidation { get; } = (DataGridView gridView, DataGridViewCellValidatingEventArgs e)
            => GenericCellValidation(gridView, e, NameRegex.IsMatch);
        private static CellValidator PatronymicCellValidation { get; } = (DataGridView gridView, DataGridViewCellValidatingEventArgs e)
            => GenericCellValidation(gridView, e, str => str == "" || NameRegex.IsMatch(str));
        private static CellValidator AlwaysTrueCellValidation { get; } = (DataGridView gridView, DataGridViewCellValidatingEventArgs e)
            => GenericCellValidation(gridView, e, _ => true);
        private static CellValidator NonEmptyCellValidator { get; } = (DataGridView gridView, DataGridViewCellValidatingEventArgs e)
            => GenericCellValidation(gridView, e, string.IsNullOrWhiteSpace);

        private CellValidator ClassIdCellValidation { get; }
        private CellValidator TeacherIdCellValidation { get; }
        private CellValidator SubjectIdCellValidation { get; }
        private CellValidator StudentIdCellValidation { get; }

        private static void GenericCellValidation
            (DataGridView gridView, DataGridViewCellValidatingEventArgs e, Predicate<string> predicate)
        {
            if (!predicate((string)e.FormattedValue) && gridView.EditingControl != null)
                gridView.EditingControl.Text = gridView.CurrentCell.Value != null ? gridView.CurrentCell.Value.ToString() : "";
        }

        private int FindLowestNotBusy(HashSet<int> set)
        {
            int i;
            for (i = 0; set.Contains(i); ++i) { }
            return i;
        }

        private void Save()
        {
            if (schoolContext == null)
            {
                SaveAs();
            }
            else
            {
                if (!DeleteChangesCheck())
                    return;
                DeleteEmptyRows();
                schoolContext.SaveChanges();
            }
        }

        private void Open()
        {
            if (schoolContext == null && !SaveDialog() ||
                schoolContext != null && schoolContext.ChangeTracker.HasChanges() && !SaveDialog())
            {
                return;
            }

            using var dialog = new OpenFileDialog();

            dialog.Filter = "Файл базы данных (*.db)|*.db";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ResetFilterToolStripMenuItem.PerformClick();

                schoolContext?.Dispose();

                schoolContext = new SchoolDbContext(dialog.FileName);

                schoolContext.Teachers.Load();
                schoolContext.Students.Load();
                schoolContext.Subjects.Load();
                schoolContext.Classes.Load();
                schoolContext.Marks.Load();

                ConnectOriginToContext();
                ConnectViewToOrigin();
                LoadIdsToSets();
            }
        }

        private bool SaveDialog()
        {
            var dialogResult = MessageBox.Show("Сохранить изменения?", "Сохранить", MessageBoxButtons.YesNoCancel);

            switch (dialogResult)
            {
                case DialogResult.Yes:
                    Save();
                    return true;
                case DialogResult.No:
                    return true;
                case DialogResult.Cancel:
                default:
                    return false;
            }
        }

        private void SaveAs()
        {
            if (!DeleteChangesCheck())
                return;

            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Файл базы данных (*.db)|*.db";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    DeleteEmptyRows();

                    schoolContext?.Dispose();

                    schoolContext = new SchoolDbContext(dialog.FileName);

                    schoolContext.Database.EnsureDeleted();
                    schoolContext.Database.EnsureCreated();

                    schoolContext.Students.AddRange(NamedOriginSources["Ученики"].Cast<Student>());
                    schoolContext.Teachers.AddRange(NamedOriginSources["Учителя"].Cast<Teacher>());
                    schoolContext.Subjects.AddRange(NamedOriginSources["Предметы"].Cast<Subject>());
                    schoolContext.Classes.AddRange(NamedOriginSources["Классы"].Cast<Class>());
                    schoolContext.Marks.AddRange(NamedOriginSources["Успеваемость"].Cast<Mark>());

                    ConnectOriginToContext();
                    ConnectViewToOrigin();

                    schoolContext.SaveChanges();
                }
            }
        }

        private bool DeleteChangesCheck()
        {
            foreach (DataGridView gridView in NamedGridViews.Values)
            {
                foreach (DataGridViewRow row in gridView.Rows)
                {
                    if (row.Cells.Cast<DataGridViewCell>().Any(cell => String.IsNullOrWhiteSpace((string)cell.FormattedValue)))
                        return MessageBox.Show(
                            "Все строки, в которых есть клетки с отстутствующими значениями, будут удалены при сохранении.\n"
                            + "Чтобы изменить значения в строках с пустыми символами нажмите \"Нет\". Иначе нажмите \"Да\"",
                            "Проверьте значения", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation
                        ) == DialogResult.Yes;
                }
            }

            return true;
        }

        private void LoadIdsToSets()
        {
            foreach (var key in NamedGridViews.Keys)
            {
                if (key != "Успеваемость")
                {
                    NamedIdsSets[key].Clear();
                    foreach (var id in (from element in ((IBindingList)NamedGridViews[key].DataSource).Cast<dynamic>() select element.I))
                        NamedIdsSets[key].Add(id);
                }
            }
        }

        private void ConnectOriginToContext()
        {
            NamedOriginSources["Ученики"] = schoolContext.Students.Local.ToBindingList();
            NamedOriginSources["Учителя"] = schoolContext.Teachers.Local.ToBindingList();
            NamedOriginSources["Предметы"] = schoolContext.Subjects.Local.ToBindingList();
            NamedOriginSources["Классы"] = schoolContext.Classes.Local.ToBindingList();
            NamedOriginSources["Успеваемость"] = schoolContext.Marks.Local.ToBindingList();
        }

        private void ConnectViewToOrigin()
        {
            studentsGridView.DataSource = NamedOriginSources["Ученики"];
            teachersGridView.DataSource = NamedOriginSources["Учителя"];
            classesGridView.DataSource = NamedOriginSources["Классы"];
            subjectsGridView.DataSource = NamedOriginSources["Предметы"];
            marksGridView.DataSource = NamedOriginSources["Успеваемость"];
        }

        private void UpdateAddButtonState() => insertButton.Enabled = AddButtonsStates[marksControl.SelectedTab.Text];

        private void UpdateDeleteButtonState() => deleteButton.Enabled = DeleteButtonsStates[marksControl.SelectedTab.Text];

        private void DeleteEmptyRows()
        {
            foreach (var key in NamedGridViews.Keys)
            {
                for (int i = 0; i < NamedGridViews[key].RowCount;)
                {
                    if (NamedGridViews[key].Rows[i].Cells.Cast<DataGridViewCell>().Any(cell => String.IsNullOrWhiteSpace((string)cell.FormattedValue)))
                    {
                        NamedIdsSets[key].Remove(((dynamic)((IBindingList)NamedGridViews[key].DataSource)[i]).I);
                        ((IBindingList)NamedGridViews[key].DataSource).RemoveAt(i);
                    }
                    else
                    {
                        ++i;
                    }
                }
            }

            foreach (var key in NamedOriginSources.Keys)
            {
                foreach (var entity in NamedOriginSources[key].Cast<object>().ToList())
                {
                    bool cascadeDeletion = entity switch
                    {
                        Student s => !IsIdExisting(s.ClassId.ToString(), teachersGridView),
                        Class s => !IsIdExisting(s.TeacherId.ToString(), teachersGridView),
                        Subject s => !IsIdExisting(s.TeacherId.ToString(), teachersGridView),
                        Mark s => !IsIdExisting(s.SubjectId.ToString(), teachersGridView) &&
                                  !IsIdExisting(s.StudentId.ToString(), teachersGridView),
                        _ => false
                    };

                    if (cascadeDeletion)
                    {
                        NamedOriginSources[key].Remove(entity);
                        ((IBindingList)NamedGridViews[key].DataSource).Remove(entity);
                    }
                }
            }
        }

        private bool IsIdExisting(string id, DataGridView gridView)
            => gridView.Rows.Cast<DataGridViewRow>().Any(row => ((string)row.Cells["I"].FormattedValue).Equals(id));

        private void DeleteSelected()
        {
            var gridView = NamedGridViews[marksControl.SelectedTab.Text];

            foreach (DataGridViewRow row in gridView.SelectedRows)
            {
                if (marksControl.SelectedTab.Text != "Успеваемость")
                    NamedIdsSets[marksControl.SelectedTab.Text].Remove((int)row.Cells["I"].Value);
                gridView.Rows.Remove(row);
            }
        }

        private void school_Load(object sender, EventArgs e)
        {
            ConnectViewToOrigin();

            studentsGridView.Columns["Id"].Visible = false;
            studentsGridView.Columns["I"].ReadOnly = true;
            studentsGridView.Columns["I"].HeaderText = "ID ученика";
            studentsGridView.Columns["Name"].HeaderText = "Имя";
            studentsGridView.Columns["Surname"].HeaderText = "Фамилия";
            studentsGridView.Columns["Patronymic"].HeaderText = "Отчество";
            studentsGridView.Columns["BirthDate"].HeaderText = "Дата рождения";
            studentsGridView.Columns["BirthDate"].CellTemplate = new DateTimeCell();
            studentsGridView.Columns["ClassId"].HeaderText = "ID класса";

            studentsGridView.AutoGenerateColumns = false;

            teachersGridView.Columns["Id"].Visible = false;
            teachersGridView.Columns["I"].ReadOnly = true;
            teachersGridView.Columns["I"].HeaderText = "ID учителя";
            teachersGridView.Columns["Name"].HeaderText = "Имя";
            teachersGridView.Columns["Surname"].HeaderText = "Фамилия";
            teachersGridView.Columns["Patronymic"].HeaderText = "Отчество";
            teachersGridView.Columns["BirthDate"].HeaderText = "Дата рождения";
            teachersGridView.Columns["BirthDate"].CellTemplate = new DateTimeCell();

            teachersGridView.AutoGenerateColumns = false;

            classesGridView.Columns["Id"].Visible = false;
            classesGridView.Columns["I"].ReadOnly = true;
            classesGridView.Columns["I"].HeaderText = "ID класса";
            classesGridView.Columns["ClassNumber"].HeaderText = "Класс";
            classesGridView.Columns["TeacherId"].HeaderText = "ID классного руководителя";

            classesGridView.AutoGenerateColumns = false;

            subjectsGridView.Columns["Id"].Visible = false;
            subjectsGridView.Columns["I"].ReadOnly = true;
            subjectsGridView.Columns["I"].HeaderText = "ID предмета";
            subjectsGridView.Columns["Name"].HeaderText = "Имя";
            subjectsGridView.Columns["TeacherId"].HeaderText = "ID учителя";

            subjectsGridView.AutoGenerateColumns = false;

            marksGridView.Columns["Id"].Visible = false;
            marksGridView.Columns["StudentId"].HeaderText = "ID ученика";
            marksGridView.Columns["SubjectId"].HeaderText = "ID предмета";
            marksGridView.Columns["MarkNum"].HeaderText = "Оценка";
            marksGridView.Columns["Date"].HeaderText = "Дата";
            marksGridView.Columns["Date"].CellTemplate = new DateTimeCell();

            marksGridView.AutoGenerateColumns = false;
            studentsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            teachersGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            classesGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            subjectsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            marksGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) => SaveAs();
        private void openToolStripMenuItem_Click(object sender, EventArgs e) => Open();
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) => Save();

        private void studentsGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            CellValidator validator = studentsGridView.Columns[e.ColumnIndex].DataPropertyName switch
            {
                "I" => AlwaysTrueCellValidation,
                "Name" => NameCellValidation,
                "Surname" => NameCellValidation,
                "Patronymic" => PatronymicCellValidation,
                "BirthDate" => AlwaysTrueCellValidation,
                "ClassId" => ClassIdCellValidation,
                _ => throw new ArgumentOutOfRangeException(nameof(e))
            };

            validator(studentsGridView, e);
        }

        private void teachersGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            CellValidator validator = teachersGridView.Columns[e.ColumnIndex].DataPropertyName switch
            {
                "I" => AlwaysTrueCellValidation,
                "Name" => NameCellValidation,
                "Surname" => NameCellValidation,
                "Patronymic" => PatronymicCellValidation,
                "BirthDate" => AlwaysTrueCellValidation,
                _ => throw new ArgumentOutOfRangeException(nameof(e))
            };

            validator(teachersGridView, e);
        }

        private void classesGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            CellValidator validator = classesGridView.Columns[e.ColumnIndex].DataPropertyName switch
            {
                "I" => AlwaysTrueCellValidation,
                "ClassNumber" => ClassCellValidation,
                "TeacherId" => TeacherIdCellValidation,
                _ => throw new ArgumentOutOfRangeException(nameof(e))
            };

            validator(classesGridView, e);
        }

        private void marksGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            CellValidator validator = classesGridView.Columns[e.ColumnIndex].DataPropertyName switch
            {
                "StudentId" => StudentIdCellValidation,
                "SubejectId" => SubjectIdCellValidation,
                "MarkNum" => MarkCellValidation,
                "Date" => AlwaysTrueCellValidation,
                _ => throw new ArgumentOutOfRangeException(nameof(e))
            };

            validator(marksGridView, e);
        }

        private void subjectsGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            CellValidator validator = classesGridView.Columns[e.ColumnIndex].DataPropertyName switch
            {
                "I" => AlwaysTrueCellValidation,
                "Name" => NonEmptyCellValidator,
                "TeacherId" => TeacherIdCellValidation,
                _ => throw new ArgumentOutOfRangeException(nameof(e))
            };

            validator(subjectsGridView, e);
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form form = marksControl.SelectedTab.Text switch
            {
                "Классы" => new ClassFilterDialog(),
                "Успеваемость" => new MarksFilterDialog(),
                "Учителя" => new TeachersFilterDialog(),
                "Предметы" => new SubjectFilterDialog(),
                "Ученики" => new StudentFilterDialog(),
                _ => throw new ArgumentOutOfRangeException()
            })
            {
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    Type type = marksControl.SelectedTab.Text switch
                    {
                        "Классы" => typeof(Class),
                        "Успеваемость" => typeof(Mark),
                        "Учителя" => typeof(Teacher),
                        "Предметы" => typeof(Subject),
                        "Ученики" => typeof(Student),
                        _ => throw new ArgumentOutOfRangeException()
                    };

                    DataGridView gridView = NamedGridViews[marksControl.SelectedTab.Text];

                    AddButtonsStates[marksControl.SelectedTab.Text] = false;

                    UpdateAddButtonState();

                    switch (marksControl.SelectedTab.Text)
                    {
                        case "Ученики":
                            gridView.DataSource = new ObservableCollection<Student>(
                                ((IBindingList)gridView.DataSource)
                                .Cast<object>().Where(((IFilterDialog)form).FilterPredicate).Cast<Student>()).ToBindingList();
                            break;
                        case "Учителя":
                            gridView.DataSource = new ObservableCollection<Teacher>(
                                ((IBindingList)gridView.DataSource)
                                .Cast<object>().Where(((IFilterDialog)form).FilterPredicate).Cast<Teacher>()).ToBindingList();
                            break;
                        case "Классы":
                            gridView.DataSource = new ObservableCollection<Class>(
                                ((IBindingList)gridView.DataSource)
                                .Cast<object>().Where(((IFilterDialog)form).FilterPredicate).Cast<Class>()).ToBindingList();
                            break;
                        case "Предметы":
                            gridView.DataSource = new ObservableCollection<Subject>(
                                ((IBindingList)gridView.DataSource)
                                .Cast<object>().Where(((IFilterDialog)form).FilterPredicate).Cast<Subject>()).ToBindingList();
                            break;
                        case "Успеваемость":
                            gridView.DataSource = new ObservableCollection<Mark>(
                                ((IBindingList)gridView.DataSource)
                                .Cast<object>().Where(((IFilterDialog)form).FilterPredicate).Cast<Mark>()).ToBindingList();
                            break;
                    }

                    ResetFilterToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void ResetFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectViewToOrigin();
            foreach (var key in AddButtonsStates.Keys)
                AddButtonsStates[key] = true;
            UpdateAddButtonState();
            ResetFilterToolStripMenuItem.Enabled = false;
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            var gridView = NamedGridViews[marksControl.SelectedTab.Text];
            var dataSource = NamedOriginSources[marksControl.SelectedTab.Text];
            var idSet = NamedIdsSets[marksControl.SelectedTab.Text];

            int newId = FindLowestNotBusy(idSet);
            idSet.Add(newId);

            object newRow = marksControl.SelectedTab.Text switch
            {
                "Ученики" => new Student { I = newId },
                "Классы" => new Class { I = newId },
                "Учителя" => new Teacher { I = newId },
                "Предметы" => new Subject { I = newId },
                "Успеваемость" => new Mark(),
                _ => throw new ArgumentOutOfRangeException(nameof(marksControl.SelectedTab.Text))
            };


            dataSource.Insert((gridView.SelectedRows.Count != 0) ?
                gridView.Rows.IndexOf(gridView.SelectedRows[gridView.SelectedRows.Count - 1]) :
                0, newRow);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteSelected();
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            UpdateAddButtonState();
            UpdateDeleteButtonState();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SearchDialog())
            {
                (dialog.FieldName, dialog.PropertyName, dialog.ValidationPredicate, dialog.ErrorString) = marksControl.SelectedTab.Text switch
                {
                    "Классы" => ("Номер класса", "ClassNumber", School.ClassRegex.IsMatch, "Введен не номер класса"),
                    "Учителя" => ("ID учителя", "I", School.IsStringNonNegativeInt, "Введено не число, либо число меньше нуля"),
                    "Предметы" => ("ID предмета", "I", School.IsStringNonNegativeInt, "Введено не число, либо число меньше нуля"),
                    "Успеваемость" => ("Оценка", "MarkNum", School.IsMarkLegit, "Введена не оценка"),
                    "Ученики" => ("ID ученика", "I", School.IsStringNonNegativeInt, "Введено не число, либо число меньше нуля"),
                    _ => throw new ArgumentOutOfRangeException(nameof(marksControl.SelectedTab.Text))
                };

                dialog.ShowDialog();

                if (dialog.DialogResult == DialogResult.OK)
                {
                    var gridView = NamedGridViews[marksControl.SelectedTab.Text];

                    foreach (DataGridViewRow row in gridView.Rows)
                        row.Selected = dialog.FilterPredicate(row);

                    if (gridView.SelectedRows.Count != 0)
                        gridView.FirstDisplayedScrollingRowIndex = gridView.SelectedRows[0].Index;
                    else
                        MessageBox.Show("Совпадений не найдено", "Поиск");
                }
            }
        }

        private void school_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (schoolContext == null || schoolContext != null && schoolContext.ChangeTracker.HasChanges())
                e.Cancel = !SaveDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void studentsGridView_SelectionChanged(object sender, EventArgs e)
        {
            DeleteButtonsStates["Ученики"] = studentsGridView.SelectedRows.Count != 0;
            UpdateDeleteButtonState();
        }

        private void teachersGridView_SelectionChanged(object sender, EventArgs e)
        {
            DeleteButtonsStates["Учителя"] = teachersGridView.SelectedRows.Count != 0;
            UpdateDeleteButtonState();
        }

        private void classesGridView_SelectionChanged(object sender, EventArgs e)
        {
            DeleteButtonsStates["Классы"] = classesGridView.SelectedRows.Count != 0;
            UpdateDeleteButtonState();
        }

        private void subjectsGridView_SelectionChanged(object sender, EventArgs e)
        {
            DeleteButtonsStates["Предметы"] = subjectsGridView.SelectedRows.Count != 0;
            UpdateDeleteButtonState();
        }

        private void marksGridView_SelectionChanged(object sender, EventArgs e)
        {
            DeleteButtonsStates["Успеваемость"] = marksGridView.SelectedRows.Count != 0;
            UpdateDeleteButtonState();
        }
    }
}
