using Karpenko.University.Backend.Core.ResultPattern;
using Karpenko.University.Backend.Domain.Student;

namespace Karpenko.University.Backend.Application.UseCases.GetStudentByExpression;

/// <summary>
/// Возможные результаты при поиске студента
/// </summary>
public static class Results {
  /// <summary>
  /// Студент не найден
  /// </summary>
  public sealed record NotFound : IResult;
  
  /// <summary>
  /// Студент найден
  /// </summary>
  public sealed record Found(StudentModel Student) : IResult;
}
