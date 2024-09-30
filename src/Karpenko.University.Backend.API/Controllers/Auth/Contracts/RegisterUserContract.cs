using CreateStudent = Karpenko.University.Backend.Application.UseCases.CreateStudent;

namespace Karpenko.University.Backend.API.Controllers.Auth.Contracts;

/// <summary>
/// Данные для регистрации пользователя
/// </summary>
/// <param name="Email">Почта</param>
/// <param name="Name">Имя</param>
/// <param name="Password">Пароль</param>
public sealed record RegisterUserContract(
  string? Email,
  string? Name,
  string? Password
) {
  /// <summary>
  /// Привести к формату данных для входных данных для сценария создания студента 
  /// </summary>
  public CreateStudent.EntryData ToCreateStudentEntryData() {
    return new CreateStudent.EntryData(
      Name,
      Email,
      Password);
  }
}
