using Karpenko.University.Backend.Application.Pagination;
using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.GetCommentsByCourseId;

/// <summary>
/// Сценарий получения комментариев курса по идентификатору
/// </summary>
public sealed class UseCase(ICommentRepository commentRepository, ICacheService cacheService) : AbstractAsyncUseCase<EntryData> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var cachedComments = await cacheService.GetFromCacheAsync(EntryData.CourseId, EntryData.Pagination, cancellationToken);

    if (cachedComments is not null)
      return new Results.CommentsCollection(cachedComments);

    var commentsCount = await commentRepository.GetCommentsCountByCourseIdAsync(EntryData.CourseId, cancellationToken);

    var comments = await commentRepository.GetCommentsWithAuthorByCourseIdAsync(
      EntryData.CourseId,
      EntryData.Pagination,
      cancellationToken);

    var commentsCollection = comments.ToPaginatedCollection(EntryData.Pagination, commentsCount);

    cacheService.SetToCacheAsync(EntryData.CourseId, commentsCollection, cancellationToken);

    return new Results.CommentsCollection(commentsCollection);
  }
}
