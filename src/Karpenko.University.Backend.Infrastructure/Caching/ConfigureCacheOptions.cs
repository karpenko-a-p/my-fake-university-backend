using Karpenko.University.Backend.Application.Caching;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Karpenko.University.Backend.Infrastructure.Caching;

/// <summary>
/// Конфигурация опций для кэширования
/// </summary>
internal sealed class ConfigureCacheOptions(IConfiguration configuration) : IConfigureOptions<CacheOptions> {
  /// <inheritdoc />
  public void Configure(CacheOptions options) {
    options.ConnectionString = configuration.GetConnectionString("Redis") ?? string.Empty;
  }
}
