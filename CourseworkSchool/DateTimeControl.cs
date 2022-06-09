using System;
using System.Windows.Forms;

namespace CourseProject
{
    /// <summary>
    /// Класс элемента управления <see cref="DateTimePicker"/> для <see cref="DataGridView"/>
    /// </summary>
    /// <remarks>
    /// Реализует интерфейс <see cref="IDataGridViewEditingControl"/>
    /// </remarks>
    class DateTimeControl : DateTimePicker, IDataGridViewEditingControl
    {
        /// <summary>
        /// Конструктор элемента управления
        /// </summary>
        public DateTimeControl()
        {
            CustomFormat = "dd.MM.yyyy HH:mm:ss";
            Format = DateTimePickerFormat.Custom;
        }

        /// <inheritdoc/>
        public object EditingControlFormattedValue
        {
            get
            {
                return Value.ToString(CustomFormat);
            }
            set
            {
                if (value is String)
                {
                    try
                    {
                        Value = DateTime.Parse((String)value);
                    }
                    catch
                    {
                        Value = DateTime.Now;
                    }
                }
            }
        }

        /// <inheritdoc/>
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context) => EditingControlFormattedValue;

        /// <inheritdoc/>
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
            CalendarForeColor = dataGridViewCellStyle.ForeColor;
            CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        /// <inheritdoc/>
        public int EditingControlRowIndex { get; set; }

        /// <inheritdoc/>
        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        /// <inheritdoc/>
        public void PrepareEditingControlForEdit(bool selectAll) { }

        /// <inheritdoc/>
        public bool RepositionEditingControlOnValueChange => false;

        /// <inheritdoc/>
        public DataGridView EditingControlDataGridView { get; set; }

        /// <inheritdoc/>
        public bool EditingControlValueChanged { get; set; } = false;

        /// <inheritdoc/>
        public Cursor EditingPanelCursor => base.Cursor;

        /// <inheritdoc/>
        protected override void OnValueChanged(EventArgs eventargs)
        {
            EditingControlValueChanged = true;
            EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }
}
