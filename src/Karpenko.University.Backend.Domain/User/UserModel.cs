namespace Karpenko.University.Backend.Domain.User;

/// <summary>
/// Модель пользователя
/// </summary>
public sealed class UserModel {
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
  public string AvatarUrl { get; set; } = string.Empty;
  
  /// <summary>
  /// Дата регистрации
  /// </summary>
  public DateTime RegistrationDate { get; set; }
}
