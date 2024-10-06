using Karpenko.University.Backend.Domain.Student;

namespace Karpenko.University.Backend.Persistence.Database.Entities;

/// <summary>
/// Сущность студента в БД
/// </summary>
internal sealed class StudentEntity {
  /// <summary>
  /// Идентификатор
  /// </summary>
  public ulong Id { get; set; }

  /// <summary>
  /// Имя
  /// </summary>
  public string Name { get; set; } = string.Empty;

  /// <summary>
  /// Электронная почта
  /// </summary>
  public string Email { get; set; } = string.Empty;

  /// <summary>
  /// Ссылка на фото
  /// </summary>
  public string? AvatarUrl { get; set; } = string.Empty;

  /// <summary>
  /// Дата регистрации
  /// </summary>
  public DateTime RegistrationDate { get; set; }

  /// <summary>
  /// Навигационное свойство на сущность с паролем
  /// </summary>
  public StudentPasswordEntity? Password { get; set; }

  /// <summary>
  /// Привести данные к формату модели студента
  /// </summary>
  public StudentModel ToStudentModel() {
    return new() {
      Id = Id,
      AvatarUrl = AvatarUrl ?? string.Empty,
      RegistrationDate = RegistrationDate,
      Name = Name,
      Email = Email,
    };
  }
}
