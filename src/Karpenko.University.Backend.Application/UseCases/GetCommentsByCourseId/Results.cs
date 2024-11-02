using Karpenko.University.Backend.Application.Pagination;
using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.GetCommentsByCourseId;

/// <summary>
/// Результаты сценария получения комментариев по курсу
/// </summary>
public static class Results {
  /// <summary>
  /// Список комментариев
  /// </summary>
  public sealed record CommentsCollection(PaginatedItems<CommentWithAuthorDto> Comments) : IResult;
}
