using CreateStudent = Karpenko.University.Backend.Application.UseCases.CreateStudent;
using GenerateJwtToken = Karpenko.University.Backend.Application.UseCases.GenerateJwtToken;
using GetStudentByEmail = Karpenko.University.Backend.Application.UseCases.GetStudentByEmail;
using VerifyStudentPassword = Karpenko.University.Backend.Application.UseCases.VerifyStudentPassword;
using GetStudentById = Karpenko.University.Backend.Application.UseCases.GetStudentById;
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
    services.AddTransient<GenerateJwtToken.UseCase>();
    services.AddTransient<VerifyStudentPassword.UseCase>();
    services.AddTransient<GetStudentByEmail.UseCase>();
    services.AddTransient<GetStudentById.UseCase>();

    return services;
  }
}
