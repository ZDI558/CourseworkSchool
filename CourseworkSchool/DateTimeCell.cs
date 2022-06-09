using System;
using System.Windows.Forms;

namespace CourseProject
{
    /// <summary>
    /// Класс ячейки таблицы, позволяющей задать время
    /// </summary>
    class DateTimeCell : DataGridViewTextBoxCell
    {
        /// <summary>
        /// Конструктор ячейки
        /// </summary>
        public DateTimeCell() : base() => Style.Format = "dd.MM.yyyy";

        /// <inheritdoc/>
        public override void InitializeEditingControl(
            int rowIndex, object initialFormattedValue,
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            ((DateTimeControl)DataGridView.EditingControl).Value = (DateTime)((DateTime)Value == DateTime.MinValue ? DefaultNewRowValue : Value);
        }

        /// <inheritdoc/>
        public override Type EditType => typeof(DateTimeControl);

        /// <inheritdoc/>
        public override Type ValueType => typeof(DateTime);

        /// <inheritdoc/>
        public override object DefaultNewRowValue => DateTime.Now;
    }
}
