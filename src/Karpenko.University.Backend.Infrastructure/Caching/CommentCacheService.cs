using Karpenko.University.Backend.Application.Pagination;
using Microsoft.Extensions.Caching.Distributed;
using GetCommentsByCourseId = Karpenko.University.Backend.Application.UseCases.GetCommentsByCourseId;

namespace Karpenko.University.Backend.Infrastructure.Caching;

/// <summary>
/// Сервис для работы с кэшем комментариев
/// </summary>
internal sealed class CommentCacheService(IDistributedCache cache) : AbstractCacheService(cache), GetCommentsByCourseId.ICacheService {
  /// <summary>
  /// Ключ кэширования для пагинированного списка комментариев
  /// </summary>
  private const string CommentsByCourseCacheKey = "comments_by_course_id-{0}_page-{1}_size-{2}";

  /// <inheritdoc />
  public Task<PaginatedItems<GetCommentsByCourseId.CommentWithAuthorDto>?> GetFromCacheAsync(
    long courseId,
    PaginationModel pagination,
    CancellationToken cancellationToken
  ) {
    var key = string.Format(CommentsByCourseCacheKey, courseId, pagination.PageNumber, pagination.PageSize);
    return GetAsync<PaginatedItems<GetCommentsByCourseId.CommentWithAuthorDto>>(key, cancellationToken);
  }

  /// <inheritdoc />
  public Task SetToCacheAsync(
    long courseId,
    PaginatedItems<GetCommentsByCourseId.CommentWithAuthorDto> comments,
    CancellationToken cancellationToken
  ) {
    var key = string.Format(CommentsByCourseCacheKey, courseId, comments.PageNumber, comments.PageSize);
    return SetAsync(
      key,
      comments,
      slidingExpiration: TimeSpan.FromMinutes(15),
      absoluteExpirationRelativeToNow: TimeSpan.FromHours(1),
      cancellationToken: cancellationToken);
  }
}
