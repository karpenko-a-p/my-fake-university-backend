namespace Karpenko.University.Backend.Persistence.Database;

/// <summary>
/// Таблицы БД
/// </summary>
internal static class Tables {
  /// <summary>
  /// Миграции БД
  /// </summary>
  public const string MigrationsHistory = "migrations_history";
  
  /// <summary>
  /// Таблица со студентами
  /// </summary>
  public const string Students = "students_data";
  
  /// <summary>
  /// Таблица с паролями студентов
  /// </summary>
  public const string StudentsPasswords = "students_passwords";
}
