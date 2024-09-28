namespace Karpenko.University.Backend.Application.UseCases.CreateStudent;

/// <summary>
/// Данные для создания аккаунта студента
/// </summary>
/// <param name="Name">Имя</param>
/// <param name="Email">Электронная почта</param>
/// <param name="Password">Пароль</param>
public sealed record EntryData(
  string? Name,
  string? Email,
  string? Password);
