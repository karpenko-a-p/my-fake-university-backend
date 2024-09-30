using System.Security.Claims;

namespace Karpenko.University.Backend.Application.UseCases.GenerateJwtToken;

/// <summary>
/// Данные для генерации jwt токена
/// </summary>
/// <param name="Issuer">Издатель токена</param>
/// <param name="Audience">Кому токен предназначается</param>
/// <param name="Secret">Секретный ключ</param>
/// <param name="Expires">Время жизни токена</param>
/// <param name="Claims">Данные зашиваемые в токен</param>
public sealed record GenerateJwtTokenDto(
  string Issuer,
  string Audience,
  string Secret,
  TimeSpan Expires,
  IEnumerable<Claim> Claims);
