using Karpenko.University.Backend.Application.Pagination;
using Karpenko.University.Backend.Core.ResultPattern;
using Karpenko.University.Backend.Domain.CourseComment;

namespace Karpenko.University.Backend.Application.UseCases.GetCommentsByAuthorId;

/// <summary>
/// Результаты сценария получения списка комментариев по идентификатору владельца
/// </summary>
public static class Results {
  /// <summary>
  /// Коллекция комментариев
  /// </summary>
  public sealed record CommentsCollection(PaginatedItems<CourseCommentModel> Comments) : IResult;
}
