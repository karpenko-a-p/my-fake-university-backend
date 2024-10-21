using Karpenko.University.Backend.Core.ResultPattern;
using Karpenko.University.Backend.Domain.CourseTag;

namespace Karpenko.University.Backend.Application.UseCases.GetTagsByCourseId;

/// <summary>
/// Результаты сценария для поиска тэгов курса
/// </summary>
public static class Results {
  /// <summary>
  /// Список тэгов
  /// </summary>
  public sealed record TagsCollection(ICollection<CourseTagModel> Tags) : IResult;
}
