using System;

namespace CourseProject
{
    /// <summary>
    /// Класс представляющий сущность "Ученик"
    /// </summary>
    /// <remarks>
    /// Содержит информацию об ученике
    /// </remarks>
    public class Student
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
        public int I { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        /// <value>
        /// Позволяет получить и задать имя
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        /// <value>
        /// Позволяет получить и задать фамилию
        /// </value>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        /// <value>
        /// Позволяет получить и задать отчество
        /// </value>
        public string Patronymic { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        /// <value>
        /// Позволяет получить и задать дату рождения
        /// </value>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// ID класса
        /// </summary>
        /// <value>
        /// Позволяет получить и задать ID класса
        /// </value>
        public int ClassId { get; set; }
    }
}