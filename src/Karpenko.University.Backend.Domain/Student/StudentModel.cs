namespace Karpenko.University.Backend.Domain.Student;

/// <summary>
/// Модель пользователя
/// </summary>
public sealed class StudentModel {
  /// <summary>
  /// Максимальная длинна почты
  /// </summary>
  public const int EmailMaxLength = 128;
  
  /// <summary>
  /// Максимальная длинна ссылки на фото
  /// </summary>
  public const int AvatarUrlMaxLength = 255;
  
  /// <summary>
  /// Максимальная длинна имени
  /// </summary>
  public const int NameMaxLength = 255;

  /// <summary>
  /// Идентификатор
  /// </summary>
  public long Id { get; set; }
  
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
  public string AvatarUrl { get; set; } = string.Empty;
  
  /// <summary>
  /// Дата регистрации
  /// </summary>
  public DateTime RegistrationDate { get; set; }
}
