using System;
using System.Windows.Forms;

namespace CourseProject
{
    /// <summary>
    /// Класс окна диалога для фильтрации учеников
    /// </summary>
    /// <remarks>
    /// Позволяет получить предикат для последующей фильтрации коллекций учеников
    /// </remarks>
    public partial class StudentFilterDialog : Form, IFilterDialog
    {
        /// <summary>
        /// Предикат для фильтрации учеников
        /// </summary>
        /// <value>
        /// Позволяет получить предикат для фильтрации учеников
        /// </value>
        public Func<object, bool> FilterPredicate => comboBox.Text switch
        {
            "Дата рождения" => obj
            => ((Student)obj).BirthDate >= fromDateTimePicker.Value
            && ((Student)obj).BirthDate <= toDateTimePicker.Value,

            "ID класса" => obj => ((Student)obj).ClassId.ToString() == textBox.Text,

            _ => throw new ArgumentOutOfRangeException(nameof(comboBox.Text))
        };

        /// <summary>
        /// Конструктор окна диалога
        /// </summary>
        public StudentFilterDialog()
        {
            InitializeComponent();
        }

        private void IntTextBoxesVisibility(bool visibility)
        {
            fromLabel.Visible = visibility;
            toLabel.Visible = visibility;

            fromDateTimePicker.Visible = visibility;
            toDateTimePicker.Visible = visibility;
        }

        private void TextBoxVisibility(bool visibility) => textBox.Visible = visibility;

        private void SwitchToIntTextBoxes()
        {
            TextBoxVisibility(false);
            IntTextBoxesVisibility(true);
        }

        private void SwitchToTextBox()
        {
            IntTextBoxesVisibility(false);
            TextBoxVisibility(true);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            switch (comboBox.Text)
            {
                case "ID класса":
                    if (!int.TryParse(textBox.Text, out int number) || number < 0)
                    {
                        errorProvider.SetError(textBox, "Введено не число, либо число меньше нуля");
                        return;
                    }
                    break;
                case "Дата рождения":
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
                case "Дата рождения":
                    SwitchToIntTextBoxes();
                    break;
                case "ID класса":
                    SwitchToTextBox();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(comboBox.Text));
            }

            errorProvider.Clear();
        }

        private void StudentFilterDialog_Load(object sender, EventArgs e)
        {
            comboBox.Text = "ID класса";
        }
    }
}
