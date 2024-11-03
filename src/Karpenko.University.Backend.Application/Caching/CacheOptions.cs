namespace Karpenko.University.Backend.Application.Caching;

/// <summary>
/// Параметра подключения к бд
/// </summary>
public sealed class CacheOptions {
  /// <summary>
  /// Строка подключения
  /// </summary>
  public string ConnectionString { get; set; } = string.Empty;
}
