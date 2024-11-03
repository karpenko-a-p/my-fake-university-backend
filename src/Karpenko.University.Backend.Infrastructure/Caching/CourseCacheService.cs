using Karpenko.University.Backend.Application.Caching;
using Karpenko.University.Backend.Application.Pagination;
using GetCourses = Karpenko.University.Backend.Application.UseCases.GetCourses;
using GetCoursesByTagId = Karpenko.University.Backend.Application.UseCases.GetCoursesByTagId;
using Karpenko.University.Backend.Domain.Course;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace Karpenko.University.Backend.Infrastructure.Caching;

/// <summary>
/// Реализация сервиса для работы с кэшем данных курсов
/// </summary>
internal sealed class CourseCacheService(IDistributedCache cache, IOptions<CacheOptions> cacheOptions) : AbstractCacheService(cache, cacheOptions),
  GetCourses.ICacheService,
  GetCoursesByTagId.ICacheService
{
  /// <summary>
  /// Ключ кэширования для пагинированного списка курсов
  /// </summary>
  private const string CourseCacheKey = "paginated_courses_page-{0}_size-{1}";

  /// <summary>
  /// Ключ кэширования для пагинированного списка курсов по тэгу
  /// </summary>
  private const string CourseByTagCacheKey = "paginated_courses_by_tag_page-{0}_size-{1}";

  /// <inheritdoc />
  public Task<PaginatedItems<CourseModel>?> GetFromCacheAsync(PaginationModel pagination, CancellationToken cancellationToken) {
    var key = string.Format(CourseCacheKey, pagination.PageNumber, pagination.PageSize);
    return GetAsync<PaginatedItems<CourseModel>>(key, cancellationToken);
  }

  /// <inheritdoc />
  public Task SetToCacheAsync(PaginatedItems<CourseModel> courses, CancellationToken cancellationToken) {
    var key = string.Format(CourseCacheKey, courses.PageNumber, courses.PageSize);
    return SetAsync(
      key,
      courses,
      slidingExpiration: TimeSpan.FromMinutes(30),
      absoluteExpirationRelativeToNow: TimeSpan.FromHours(3),
      cancellationToken: cancellationToken);
  }

  /// <inheritdoc />
  Task<PaginatedItems<CourseModel>?> GetCoursesByTagId.ICacheService.GetFromCacheAsync(
    PaginationModel pagination,
    CancellationToken cancellationToken
  ) {
    var key = string.Format(CourseByTagCacheKey, pagination.PageNumber, pagination.PageSize);
    return GetAsync<PaginatedItems<CourseModel>>(key, cancellationToken);
  }
  
  /// <inheritdoc />
  Task GetCoursesByTagId.ICacheService.SetToCacheAsync(PaginatedItems<CourseModel> courses, CancellationToken cancellationToken) {
    var key = string.Format(CourseByTagCacheKey, courses.PageNumber, courses.PageSize);
    return SetAsync(
      key,
      courses,
      slidingExpiration: TimeSpan.FromMinutes(30),
      absoluteExpirationRelativeToNow: TimeSpan.FromHours(3),
      cancellationToken: cancellationToken);
  }
}
