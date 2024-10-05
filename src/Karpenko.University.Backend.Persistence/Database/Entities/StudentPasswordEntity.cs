namespace Karpenko.University.Backend.Persistence.Database.Entities;

/// <summary>
/// Сущность для таблицы с паролями студентов
/// </summary>
internal sealed class StudentPasswordEntity {
  /// <summary>
  /// Идентификатор студента
  /// </summary>
  public ulong StudentId { get; set; }
  
  /// <summary>
  /// Пароль
  /// </summary>
  public string Password { get; set; } = string.Empty;
  
  /// <summary>
  /// Навигационное свойство на сущность студента
  /// </summary>
  public StudentEntity Student { get; set; } = new();
}
