using CreateStudent = Karpenko.University.Backend.Application.UseCases.CreateStudent;
using GenerateJwtToken = Karpenko.University.Backend.Application.UseCases.GenerateJwtToken;
using GetStudentByExpression = Karpenko.University.Backend.Application.UseCases.GetStudentByExpression;
using VerifyStudentPassword = Karpenko.University.Backend.Application.UseCases.VerifyStudentPassword;
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
    services.AddTransient<GetStudentByExpression.UseCase>();
    services.AddTransient<VerifyStudentPassword.UseCase>();

    return services;
  }
}
