using Karpenko.University.Backend.Core.ResultPattern;
using Karpenko.University.Backend.Domain.Course;

namespace Karpenko.University.Backend.Application.UseCases.GetCourseById;

/// <summary>
/// Результат поиска курса по идентификатору
/// </summary>
public static class Results {
  /// <summary>
  /// Курс не найден
  /// </summary>
  public sealed record NotFound : IResult;
  
  /// <summary>
  /// Курс найден
  /// </summary>
  public sealed record Found(CourseModel Course) : IResult;
}
