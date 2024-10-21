namespace Karpenko.University.Backend.Application.Caching;

/// <summary>
/// Базовый сервис для работы с кэшем
/// </summary>
public interface IBaseCacheService<TModel> where TModel : class {
  /// <summary>
  /// Получение данных из кэша
  /// </summary>
  Task<TModel?> GetFromCacheAsync(CancellationToken cancellationToken);

  /// <summary>
  /// Сохранение данных в кэш
  /// </summary>
  Task SetToCacheAsync(TModel model, CancellationToken cancellationToken);
}
