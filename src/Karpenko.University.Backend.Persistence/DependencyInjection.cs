using Karpenko.University.Backend.Application.UseCases.CreateStudent;
using Karpenko.University.Backend.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Karpenko.University.Backend.Persistence;

/// <summary>
/// Внедрение слоя Persistence
/// </summary>
public static class DependencyInjection {
  /// <summary>
  /// Метод для добавления слоя к списку сервисов
  /// </summary>
  public static IServiceCollection AddPersistence(this IServiceCollection services) {
    services.AddScoped<IStudentRepository, StudentRepository>();
    
    return services;
  }
}
