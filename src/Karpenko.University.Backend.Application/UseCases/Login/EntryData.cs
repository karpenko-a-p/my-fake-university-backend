namespace Karpenko.University.Backend.Application.UseCases.Login;

/// <summary>
/// Данные для авторизации пользователя
/// </summary>
/// <param name="Email">Почта</param>
/// <param name="Password">Пароль</param>
public sealed record EntryData(
  string? Email,
  string? Password);
