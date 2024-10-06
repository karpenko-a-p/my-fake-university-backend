using Karpenko.University.Backend.Core.ResultPattern;
using Karpenko.University.Backend.Domain.Student;

namespace Karpenko.University.Backend.Application.UseCases.GetStudentByEmail;

/// <summary>
/// Результаты сценария поиска студента по почте
/// </summary>
public static class Results {
  /// <summary>
  /// Запись студента найдена
  /// </summary>
  public sealed record Found(StudentModel Student) : IResult;

  /// <summary>
  /// Запись студента не найдена
  /// </summary>
  public sealed record NotFound : IResult;
}
