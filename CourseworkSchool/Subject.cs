namespace CourseProject
{
    /// <summary>
    /// Класс представляющий сущность предмета в базе данных
    /// </summary>
    /// <remarks>
    /// Содержит информацию о предмете
    /// </remarks>
    public class Subject
    {
        /// <summary>
        /// ID для базы данных
        /// </summary>
        /// <value>
        /// Позволяет получить и задать ID для базы данных
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// ID предмета
        /// </summary>
        /// <value>
        /// Позволяет получить и задать ID предмета
        /// </value>
        public int I { get; set; }

        /// <summary>
        /// Название предмета
        /// </summary>
        /// <value>
        /// Позволяет получить и задать имя предмета
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// ID учителя
        /// </summary>
        /// <value>
        /// Позволяет получить и задать ID учителя
        /// </value>
        public int TeacherId { get; set; }
    }
}
