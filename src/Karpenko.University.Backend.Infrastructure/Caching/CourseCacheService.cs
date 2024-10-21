﻿using Karpenko.University.Backend.Application.Pagination;
using GetCourses = Karpenko.University.Backend.Application.UseCases.GetCourses;
using Karpenko.University.Backend.Domain.Course;
using Microsoft.Extensions.Caching.Distributed;

namespace Karpenko.University.Backend.Infrastructure.Caching;

/// <summary>
/// Реализация сервиса для работы с кэшем данных курсов
/// </summary>
internal sealed class CourseCacheService(IDistributedCache cache) : AbstractCacheService(cache), GetCourses.ICacheService {
  /// <summary>
  /// Ключ кэширования для пагинированного списка курсов
  /// </summary>
  private const string CourseCacheKey = "paginated_courses_page-{0}_size-{1}";

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
}