using Microsoft.EntityFrameworkCore;

namespace CourseProject
{
    /// <summary>
    /// Класс контекста базы данных школы
    /// </summary>
    /// <remarks>
    /// Содержит в себе коллекции сущностей учеников, учителей, классов, предметов, оценок
    /// </remarks>
    class SchoolDbContext : SqliteContext
    {
        /// <summary>
        /// Конструктор контекста
        /// </summary>
        /// <param name="filename">
        /// Имя файла для создания файла базы данных
        /// </param>
        public SchoolDbContext(string filename) : base(filename) { }

        /// <summary>
        /// Коллекция учителей в контексте
        /// </summary>
        /// <value>
        /// Позволяет получить и задать новую коллекцию учителей
        /// </value>
        public DbSet<Teacher> Teachers { get; set; }

        /// <summary>
        /// Коллекция учеников в контексте
        /// </summary>
        /// <value>
        /// Позволяет получить и задать новую коллекцию учеников
        /// </value>
        public DbSet<Student> Students { get; set; }

        /// <summary>
        /// Коллекция предметов в контексте
        /// </summary>
        /// <value>
        /// Позволяет получить и задать новую коллекцию предметов
        /// </value>
        public DbSet<Subject> Subjects { get; set; }
        /// <summary>
        /// Коллекция классов в контексте
        /// </summary>
        /// <value>
        /// Позволяет получить и задать новую коллекцию классов
        /// </value>
        public DbSet<Class> Classes { get; set; }
        /// <summary>
        /// Коллекция оценок в контексте
        /// </summary>
        /// <value>
        /// Позволяет получить и задать новую коллекцию оценок
        /// </value>
        public DbSet<Mark> Marks { get; set; }
    }
}
