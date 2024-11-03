using Karpenko.University.Backend.Application.Caching;
using Karpenko.University.Backend.Application.Pagination;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using GetCommentsByCourseId = Karpenko.University.Backend.Application.UseCases.GetCommentsByCourseId;
using CreateComment = Karpenko.University.Backend.Application.UseCases.CreateComment;
using DeleteCommentById = Karpenko.University.Backend.Application.UseCases.DeleteCommentById;

namespace Karpenko.University.Backend.Infrastructure.Caching;

/// <summary>
/// Сервис для работы с кэшем комментариев
/// </summary>
internal sealed class CommentCacheService(IDistributedCache cache, IOptions<CacheOptions> cacheOptions) : AbstractCacheService(cache, cacheOptions),
  GetCommentsByCourseId.ICacheService,
  CreateComment.ICacheService,
  DeleteCommentById.ICacheService
{
  /// <summary>
  /// Ключ кэширования для пагинированного списка комментариев
  /// </summary>
  private const string CommentsByCourseCacheKey = "comments_by_course_id-{0}_page-{1}_size-{2}";
  
  /// <summary>
  /// Паттерн очистки кэширования для пагинированного списка комментариев
  /// </summary>
  private const string PatternCommentsByCourseCacheKey = "comments_by_course_id-{0}*";

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

  /// <inheritdoc />
  public async Task ClearCacheByCourseIdAsync(long courseId, CancellationToken cancellationToken) {
    await RemoveByPatternAsync(string.Format(PatternCommentsByCourseCacheKey, courseId), cancellationToken);
  }
}
