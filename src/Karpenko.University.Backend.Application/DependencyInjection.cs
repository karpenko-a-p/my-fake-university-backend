using CreateStudent = Karpenko.University.Backend.Application.UseCases.CreateStudent;
using GenerateJwtToken = Karpenko.University.Backend.Application.UseCases.GenerateJwtToken;
using GetStudentByEmail = Karpenko.University.Backend.Application.UseCases.GetStudentByEmail;
using VerifyStudentPassword = Karpenko.University.Backend.Application.UseCases.VerifyStudentPassword;
using AddAccess = Karpenko.University.Backend.Application.UseCases.AddAccess;
using GetStudentById = Karpenko.University.Backend.Application.UseCases.GetStudentById;
using CheckAccess = Karpenko.University.Backend.Application.UseCases.CheckAccess;
using DeleteStudentById = Karpenko.University.Backend.Application.UseCases.DeleteStudentById;
using GetCourses = Karpenko.University.Backend.Application.UseCases.GetCourses;
using GetCourseById = Karpenko.University.Backend.Application.UseCases.GetCourseById;
using GetCoursesTags = Karpenko.University.Backend.Application.UseCases.GetCoursesTags;
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
    // Сценарии использования
    services.AddTransient<CreateStudent.UseCase>();
    services.AddTransient<GenerateJwtToken.UseCase>();
    services.AddTransient<VerifyStudentPassword.UseCase>();
    services.AddTransient<GetStudentByEmail.UseCase>();
    services.AddTransient<GetStudentById.UseCase>();
    services.AddTransient<DeleteStudentById.UseCase>();
    services.AddTransient<CheckAccess.UseCase>();
    services.AddTransient<AddAccess.UseCase>();
    services.AddTransient<GetCourses.UseCase>();
    services.AddTransient<GetCourseById.UseCase>();
    services.AddTransient<GetCoursesTags.UseCase>();

    return services;
  }
}
