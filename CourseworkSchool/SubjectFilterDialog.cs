using System;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class SubjectFilterDialog : Form, IFilterDialog
    {
        /// <summary>
        /// Предикат для фильтрации предметов
        /// </summary>
        /// <value>
        /// Позволяет получить предикат для фильтрации предметов
        /// </value>
        public Func<object, bool> FilterPredicate => obj => ((Subject)obj).TeacherId.ToString() == textBox.Text;

        /// <summary>
        /// Конструктор окна диалога
        /// </summary>
        public SubjectFilterDialog()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!School.IsStringNonNegativeInt(textBox.Text))
            {
                errorProvider.SetError(textBox, "Введено не число или число меньшее нуля");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SubjectFilterDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
