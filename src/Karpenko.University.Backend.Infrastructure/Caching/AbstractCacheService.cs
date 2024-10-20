using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Converters;

namespace Karpenko.University.Backend.Infrastructure.Caching;

/// <summary>
/// Абстрактный сервис со вспомогательными инструментами для кэширования
/// </summary>
internal abstract class AbstractCacheService(IDistributedCache cache) {
  /// <summary>
  /// Параметры сериализации
  /// </summary>
  private static readonly JsonSerializerSettings SerializerSettings = new() {
    Converters = [new StringEnumConverter()]
  };

  /// <summary>
  /// Кэширование какого-либо значения
  /// </summary>
  protected Task SetAsync<TValue>(
    string key, 
    TValue? value,
    TimeSpan? slidingExpiration = null,
    TimeSpan? absoluteExpirationRelativeToNow = null,
    DateTimeOffset? absoluteExpiration = null,
    CancellationToken cancellationToken = default
  ) where TValue : class {
    if (value is null)
      return Task.CompletedTask;

    var cacheOptions = new DistributedCacheEntryOptions {
      SlidingExpiration = slidingExpiration ?? TimeSpan.FromMinutes(5),
      AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow ?? TimeSpan.FromMinutes(30),
      AbsoluteExpiration = absoluteExpiration,
    };

    var serializedValue = JsonConvert.SerializeObject(value, SerializerSettings);

    return cache.SetAsync(key, Encoding.UTF8.GetBytes(serializedValue), cacheOptions, cancellationToken);
  }

  /// <summary>
  /// Получение значения из кэша
  /// </summary>
  protected async Task<TValue?> GetAsync<TValue>(string key, CancellationToken cancellationToken) where TValue : class {
    var value = await cache.GetStringAsync(key, cancellationToken);

    if (value is null)
      return null;
    
    return JsonConvert.DeserializeObject<TValue>(value, SerializerSettings);
  }
}
