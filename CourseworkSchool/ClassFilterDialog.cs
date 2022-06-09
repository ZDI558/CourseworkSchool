using System;
using System.Windows.Forms;

namespace CourseProject
{
    /// <summary>
    /// Класс окна диалога для фильтрации классов
    /// </summary>
    /// <remarks>
    /// Позволяет получить предикат для последующей фильтрации классов
    /// </remarks>
    public partial class ClassFilterDialog : Form, IFilterDialog
    {
        /// <summary>
        /// Предикат для фильтрации классов
        /// </summary>
        /// <value>
        /// Позволяет получить предикат для фильтрации классов
        /// </value>
        public Func<object, bool> FilterPredicate => obj => ((Class)obj).TeacherId.ToString() == textBox.Text;

        /// <summary>
        /// Конструктор окна диалога
        /// </summary>
        public ClassFilterDialog()
        {
            InitializeComponent();
        }

        private void MoneyOperationFilterDialog_Load(object sender, EventArgs e)
        {
            AcceptButton = FormOkButton;
            CancelButton = FormCancelButton;
        }

        private void FormOkButton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if (!School.IsStringNonNegativeInt(textBox.Text))
            {
                errorProvider.SetError(textBox, "Введено не число, либо число меньше нуля");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void FormCancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
