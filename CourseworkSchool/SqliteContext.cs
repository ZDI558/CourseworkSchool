using Microsoft.EntityFrameworkCore;

namespace CourseProject
{
    /// <summary>
    /// Класс контекста для SQLite базы данных
    /// </summary>
    class SqliteContext : DbContext
    {
        private readonly string dbname;

        /// <summary>
        /// Конструктор контекста
        /// </summary>
        /// <param name="filename">
        /// Имя файла, в котором требуется открыть базу данных
        /// </param>
        public SqliteContext(string filename) => dbname = filename;

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + dbname);
        }
    }
}
