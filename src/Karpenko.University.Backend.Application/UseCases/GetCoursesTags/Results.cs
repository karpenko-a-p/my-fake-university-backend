using Karpenko.University.Backend.Core.ResultPattern;
using Karpenko.University.Backend.Domain.CourseTag;

namespace Karpenko.University.Backend.Application.UseCases.GetCoursesTags;

/// <summary>
/// Результаты сценария получения всех тэгов курсов
/// </summary>
public static class Results {
  /// <summary>
  /// Список тэгов
  /// </summary>
  public sealed record TagsCollection(ICollection<CourseTagModel> Tags) : IResult;
}
