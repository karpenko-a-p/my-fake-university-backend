namespace Karpenko.University.Backend.Application.UseCases.VerifyStudentPassword;

/// <summary>
/// Данные для верификации пароля студента
/// </summary>
/// <param name="Id">Идентификатор студента</param>
/// <param name="Password">Пароль</param>
public sealed record EntryData(
  ulong? Id,
  string? Password);
