using System;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class TeachersFilterDialog : Form, IFilterDialog
    {
        /// <summary>
        /// Предикат для фильтрации учителей
        /// </summary>
        /// <value>
        /// Позволяет получить предикат для фильтрации учителей
        /// </value>
        public Func<object, bool> FilterPredicate => obj
            => ((Teacher)obj).BirthDate >= fromDateTimePicker.Value
            && ((Teacher)obj).BirthDate <= toDateTimePicker.Value;

        /// <summary>
        /// Конструктор окна диалога
        /// </summary>
        public TeachersFilterDialog()
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

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void TeachersFilterDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
