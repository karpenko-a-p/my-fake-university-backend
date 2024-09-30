namespace Karpenko.University.Backend.Application.UseCases.GenerateJwtToken;

/// <summary>
/// Данные авторизации
/// </summary>
/// <param name="Issuer">Издатель токена</param>
/// <param name="Audience">Кому токен предназначается</param>
/// <param name="Secret">Секретный ключ</param>
/// <param name="CookieName">Название куки для хранения токена</param>
public sealed record AuthOptions(
  string Issuer,
  string Audience,
  string Secret,
  string CookieName);
