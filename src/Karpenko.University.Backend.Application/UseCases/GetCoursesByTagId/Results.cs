using Karpenko.University.Backend.Application.Pagination;
using Karpenko.University.Backend.Core.ResultPattern;
using Karpenko.University.Backend.Domain.Course;

namespace Karpenko.University.Backend.Application.UseCases.GetCoursesByTagId;

/// <summary>
/// Результаты сценария получения списка курсов по тэгу
/// </summary>
public static class Results {
  /// <summary>
  /// Список курсов
  /// </summary>
  public sealed record CoursesCollection(PaginatedItems<CourseModel> Courses) : IResult;
}
