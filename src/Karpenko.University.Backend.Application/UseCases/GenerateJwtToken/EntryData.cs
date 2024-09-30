namespace Karpenko.University.Backend.Application.UseCases.GenerateJwtToken;

/// <summary>
/// Данные для генерации токена
/// </summary>
/// <param name="Id">Идентификатор пользователя</param>
/// <param name="Email">Почта</param>
public sealed record EntryData(
  ulong? Id,
  string? Email);
