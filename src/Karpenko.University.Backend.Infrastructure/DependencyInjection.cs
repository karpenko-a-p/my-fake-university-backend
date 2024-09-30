using Karpenko.University.Backend.Application.Validation;
using Karpenko.University.Backend.Infrastructure.Services;
using Karpenko.University.Backend.Infrastructure.Validation;
using Microsoft.Extensions.DependencyInjection;
using CreateStudent = Karpenko.University.Backend.Application.UseCases.CreateStudent;
using GenerateJwtToken = Karpenko.University.Backend.Application.UseCases.GenerateJwtToken;

namespace Karpenko.University.Backend.Infrastructure;

/// <summary>
/// Внедрение слоя Infrastructure
/// </summary>
public static class DependencyInjection {
  /// <summary>
  /// Метод для добавления слоя к списку сервисов
  /// </summary>
  public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
    // Сервисы
    services.AddSingleton<CreateStudent.IPasswordService, PasswordService>();
    services.AddSingleton<GenerateJwtToken.IJwtService, JwtService>();
    
    // Валидаторы
    services.AddSingleton<IValidator<CreateStudent.EntryData>, CreateStudentEntryDataValidator>();
    services.AddSingleton<IValidator<GenerateJwtToken.EntryData>, GenerateJwtTokenEntryDataValidator>();

    return services;
  }
}
