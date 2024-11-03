using Karpenko.University.Backend.Application.Caching;
using GetCoursesTags = Karpenko.University.Backend.Application.UseCases.GetCoursesTags;
using Karpenko.University.Backend.Domain.CourseTag;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace Karpenko.University.Backend.Infrastructure.Caching;

/// <summary>
/// Сервис для работы с кэшем тэгов курсов
/// </summary>
internal sealed class CourseTagCacheService(IDistributedCache cache, IOptions<CacheOptions> cacheOptions) : AbstractCacheService(cache, cacheOptions), GetCoursesTags.ICacheService {
  /// <summary>
  /// Ключ кэширования для списка всех тэгов курсов
  /// </summary>
  private const string TagsCacheKey = "courses_tags";
  
  /// <inheritdoc />
  public Task<ICollection<CourseTagModel>?> GetFromCacheAsync(CancellationToken cancellationToken) {
    return GetAsync<ICollection<CourseTagModel>>(TagsCacheKey, cancellationToken);
  }

  /// <inheritdoc />
  public Task SetToCacheAsync(ICollection<CourseTagModel> tags, CancellationToken cancellationToken) {
    return SetAsync(
      TagsCacheKey,
      tags,
      slidingExpiration: TimeSpan.FromMinutes(30),
      absoluteExpirationRelativeToNow: TimeSpan.FromHours(3),
      cancellationToken: cancellationToken);
  }
}
