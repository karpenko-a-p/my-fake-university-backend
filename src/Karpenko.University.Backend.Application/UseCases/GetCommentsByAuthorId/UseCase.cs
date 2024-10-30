using Karpenko.University.Backend.Application.Pagination;
using Karpenko.University.Backend.Core.ResultPattern;
using Karpenko.University.Backend.Domain.CourseComment;

namespace Karpenko.University.Backend.Application.UseCases.GetCommentsByAuthorId;

/// <summary>
/// Сценарий получения всех комментариев студента по идентификатору
/// </summary>
public sealed class UseCase(ICommentRepository commentRepository) : AbstractAsyncUseCase<EntryData> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var commentsCount = await commentRepository.GetCommentsCountByAuthorIdAsync(
      EntryData.AuthorId,
      cancellationToken);

    if (commentsCount is 0) {
      var emptyCollection = new List<CourseCommentModel>().ToPaginatedCollection(EntryData.Pagination, commentsCount);
      return new Results.CommentsCollection(emptyCollection);
    }

    var comments = await commentRepository.GetCommentsByAuthorIdAsync(
      EntryData.AuthorId,
      EntryData.Pagination,
      cancellationToken);

    var paginatedItems = comments.ToPaginatedCollection(EntryData.Pagination, commentsCount);

    return new Results.CommentsCollection(paginatedItems);
  }
}
