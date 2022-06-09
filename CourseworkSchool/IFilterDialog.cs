using System;

namespace CourseProject
{
    /// <summary>
    /// Интерфейс для окна диалога 
    /// </summary>
    /// <remarks>
    /// Содержит свойство с предикатом для фильтрации сущностей
    /// </remarks>
    interface IFilterDialog
    {
        /// <summary>
        /// Предикат для фильтрации сущностей
        /// </summary>
        /// <value>
        /// Позволяет получить предикат для фильтрации сущностей
        /// </value>
        Func<object, bool> FilterPredicate { get; }
    }
}
