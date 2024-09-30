namespace Karpenko.University.Backend.Application.UseCases.GenerateJwtToken;

/// <summary>
/// Данные авторизации
/// </summary>
public sealed class AuthOptions {
  /// <summary>
  /// Издатель токена
  /// </summary>
  public string Issuer { get; set; } = string.Empty;

  /// <summary>
  /// Кому токен предназначается
  /// </summary>
  public string Audience { get; set; } = string.Empty;
  
  /// <summary>
  /// Секретный ключ
  /// </summary>
  public string Secret { get; set; } = string.Empty;
  
  /// <summary>
  /// Название куки для хранения токена
  /// </summary>
  public string CookieName { get; set; } = string.Empty;
}
