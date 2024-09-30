namespace Karpenko.University.Backend.API.Controllers.Auth.Contracts;

/// <summary>
/// Контракт данных для авторизации пользователя
/// </summary>
/// <param name="Email">Почта</param>
/// <param name="Password">Пароль</param>
public sealed record LoginUserContract(
  string? Email,
  string? Password);
