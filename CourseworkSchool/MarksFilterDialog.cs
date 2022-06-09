using System;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class MarksFilterDialog : Form, IFilterDialog
    {
        /// <summary>
        /// Предикат для фильтрации оценок
        /// </summary>
        /// <value>
        /// Позволяет получить предикат для фильтрации оценок
        /// </value>
        public Func<object, bool> FilterPredicate => comboBox.Text switch
        {
            "Дата" => obj
            => ((Mark)obj).Date >= fromDateTimePicker.Value
            && ((Mark)obj).Date <= toDateTimePicker.Value,

            "ID ученика" => obj => ((Mark)obj).StudentId.ToString() == textBox.Text,
            "ID предмета" => obj => ((Mark)obj).SubjectId.ToString() == textBox.Text,
            "Оценка" => obj => ((Mark)obj).MarkNum.ToString() == textBox.Text,

            _ => throw new ArgumentOutOfRangeException(nameof(comboBox.Text))
        };

        /// <summary>
        /// Конструктор окна диалога
        /// </summary>
        public MarksFilterDialog()
        {
            InitializeComponent();
        }

        private void DateTimePickersVisibility(bool visibility)
        {
            fromLabel.Visible = visibility;
            toLabel.Visible = visibility;

            fromDateTimePicker.Visible = visibility;
            toDateTimePicker.Visible = visibility;
        }

        private void TextBoxVisibility(bool visibility) => textBox.Visible = visibility;

        private void SwitchToDateTimePickers()
        {
            TextBoxVisibility(false);
            DateTimePickersVisibility(true);
        }

        private void SwitchToTextBox()
        {
            DateTimePickersVisibility(false);
            TextBoxVisibility(true);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            switch (comboBox.Text)
            {
                case "ID ученика":
                case "ID предмета":
                    if (!int.TryParse(textBox.Text, out int number) || number < 0)
                    {
                        errorProvider.SetError(textBox, "Введено не число, либо число меньше нуля");
                        return;
                    }
                    break;
                case "Оценка":
                    if (!School.IsMarkLegit(textBox.Text))
                    {
                        errorProvider.SetError(textBox, "Введено не число от 1 до 5");
                        return;
                    }
                    break;
                case "Дата":
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(comboBox.Text));
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void comboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (comboBox.Text)
            {
                case "Дата":
                    SwitchToDateTimePickers();
                    break;
                case "Оценка":
                case "ID ученика":
                case "ID предмета":
                    SwitchToTextBox();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(comboBox.Text));
            }

            errorProvider.Clear();
        }

        private void StudentFilterDialog_Load(object sender, EventArgs e)
        {
            comboBox.Text = "Оценка";
        }
    }
}
