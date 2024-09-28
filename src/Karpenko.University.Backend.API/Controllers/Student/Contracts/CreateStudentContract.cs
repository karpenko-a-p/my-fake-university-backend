using CreateStudent =Karpenko.University.Backend.Application.UseCases.CreateStudent;

namespace Karpenko.University.Backend.API.Controllers.Student.Contracts;

/// <summary>
/// Контракт данных для создания модели студента
/// </summary>
/// <param name="Name">Имя</param>
/// <param name="Email">Почта</param>
/// <param name="Password">Пароль</param>
public sealed record CreateStudentContract(
  string? Name,
  string? Email,
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
};
