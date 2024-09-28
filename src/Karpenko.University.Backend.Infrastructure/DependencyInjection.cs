using Karpenko.University.Backend.Application.UseCases.CreateStudent;
using Karpenko.University.Backend.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Karpenko.University.Backend.Infrastructure;

/// <summary>
/// Внедрение слоя Infrastructure
/// </summary>
public static class DependencyInjection {
  /// <summary>
  /// Метод для добавления слоя к списку сервисов
  /// </summary>
  public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
    services.AddSingleton<IPasswordService, PasswordService>();

    return services;
  }
}
