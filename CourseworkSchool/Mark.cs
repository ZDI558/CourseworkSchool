using System;

namespace CourseProject
{
    /// <summary>
    /// Класс представляющий сущность оценки в базе данных
    /// </summary>
    /// <remarks>
    /// Содержит информацию об оценке
    /// </remarks>
    public class Mark
    {
        /// <summary>
        /// ID для базы данных
        /// </summary>
        /// <value>
        /// Позволяет получить и задать ID для базы данных
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// ID ученика
        /// </summary>
        /// <value>
        /// Позволяет получить и задать ID ученика
        /// </value>
        public int StudentId { get; set; }

        /// <summary>
        /// ID предмета
        /// </summary>
        /// <value>
        /// Позволяет получить и задать ID предмета
        /// </value>
        public int SubjectId { get; set; }

        /// <summary>
        /// Оценка
        /// </summary>
        /// <value>
        /// Позволяет получить и задать оценку
        /// </value>
        public int MarkNum { get; set; }

        /// <summary>
        /// Дата выставления оценки
        /// </summary>
        /// <value>
        /// Позволяет получить и задать дату выставления оценки
        /// </value>
        public DateTime Date { get; set; }
    }
}
