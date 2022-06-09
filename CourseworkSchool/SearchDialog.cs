using System;
using System.Windows.Forms;

namespace CourseProject
{
    /// <summary>
    /// Класс окна диалога для поиска сущностей
    /// </summary>
    /// <remarks>
    /// Позволяет получить предикат для фильтрации и задать свойства сущности
    /// </remarks>
    public partial class SearchDialog : Form
    {
        /// <summary>
        /// Предикат для фильтрации сущностей
        /// </summary>
        /// <value>
        /// Позволяет получить предикат для фильтрации сущностей
        /// </value>
        public Func<object, bool> FilterPredicate { get; }

        /// <summary>
        /// Имя поля
        /// </summary>
        /// <value>
        /// Позволяет получить и задать имя поля
        /// </value>
        public string FieldName
        {
            get => label.Text;
            set => label.Text = value;
        }

        /// <summary>
        /// Имя свойства
        /// </summary>
        /// <value>
        /// Позволяет получить и задать имя свойства
        /// </value>
        public string PropertyName { get; set; }

        /// <summary>
        /// Строка ошибки для валидации
        /// </summary>
        /// <value>
        /// Позволяет получить и задать строку ошибки
        /// </value>
        public string ErrorString { get; set; }

        /// <summary>
        /// Предикат для валидации поля диалога
        /// </summary>
        /// <value>
        /// Позволяет получить предикат для валидации поля диалога
        /// </value>
        public Predicate<string> ValidationPredicate { get; set; }

        /// <summary>
        /// Конструктор окна диалога
        /// </summary>
        public SearchDialog()
        {
            InitializeComponent();
            FilterPredicate = obj => ((DataGridViewRow)obj).Cells[PropertyName].Value.ToString().Equals(textBox.Text);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!ValidationPredicate(textBox.Text))
            {
                errorProvider.SetError(textBox, ErrorString);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SearchDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
