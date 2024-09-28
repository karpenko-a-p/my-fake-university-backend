using CreateStudent = Karpenko.University.Backend.Application.UseCases.CreateStudent;
using Microsoft.Extensions.DependencyInjection;

namespace Karpenko.University.Backend.Application;

/// <summary>
/// Внедрение слоя Application
/// </summary>
public static class DependencyInjection {
  /// <summary>
  /// Метод для добавления слоя к списку сервисов
  /// </summary>
  public static IServiceCollection AddApplication(this IServiceCollection services) {
    services.AddTransient<CreateStudent.UseCase>();

    return services;
  }
}
