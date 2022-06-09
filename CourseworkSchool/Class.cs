namespace CourseProject
{
    /// <summary>
    /// Класс представляющий сущность класса в базе данных
    /// </summary>
    /// <remarks>
    /// Содержит информацию об класса
    /// </remarks>
    public class Class
    {
        /// <summary>
        /// ID для базы данных
        /// </summary>
        /// <value>
        /// Позволяет получить и задать ID для базы данных
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// ID класса
        /// </summary>
        /// <value>
        /// Позволяет получить и задать ID класса
        /// </value>
        public int I { get; set; }

        /// <summary>
        /// Номер класса
        /// </summary>
        /// <value>
        /// Позволяет получить и задать номер класса
        /// </value>
        public string ClassNumber { get; set; }

        /// <summary>
        /// ID учителя
        /// </summary>
        /// <value>
        /// Позволяет получить и задать ID учителя
        /// </value>
        public int TeacherId { get; set; }
    }
}
