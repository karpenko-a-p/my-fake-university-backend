using Karpenko.University.Backend.Persistence.Database;
using Karpenko.University.Backend.Persistence.Database.Contexts;
using CreateStudent = Karpenko.University.Backend.Application.UseCases.CreateStudent;
using VerifyStudentPassword = Karpenko.University.Backend.Application.UseCases.VerifyStudentPassword;
using GetStudentByEmail = Karpenko.University.Backend.Application.UseCases.GetStudentByEmail;
using GetStudentById = Karpenko.University.Backend.Application.UseCases.GetStudentById;
using DeleteStudentById = Karpenko.University.Backend.Application.UseCases.DeleteStudentById;
using CheckAccess = Karpenko.University.Backend.Application.UseCases.CheckAccess;
using AddAccess = Karpenko.University.Backend.Application.UseCases.AddAccess;
using GetCourses = Karpenko.University.Backend.Application.UseCases.GetCourses;
using GetCourseById = Karpenko.University.Backend.Application.UseCases.GetCourseById;
using GetCoursesTags = Karpenko.University.Backend.Application.UseCases.GetCoursesTags;
using GetTagsByCourseId = Karpenko.University.Backend.Application.UseCases.GetTagsByCourseId;
using Karpenko.University.Backend.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Karpenko.University.Backend.Persistence;

/// <summary>
/// Внедрение слоя Persistence
/// </summary>
public static class DependencyInjection {
  /// <summary>
  /// Метод для добавления слоя к списку сервисов
  /// </summary>
  public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) {
    // Контексты БД
    services.AddTriggeredDbContextPool<PostgresDbContext>(options => {
      options
        .UseNpgsql(configuration.GetConnectionString("Postgres"), npgOptions => {
          npgOptions.MigrationsHistoryTable(
            tableName: Tables.MigrationsHistory,
            schema: Schemas.UniversityBackend);
        })
        .UseSnakeCaseNamingConvention();
    });
    services.AddAssemblyTriggers();

    // Репозитории
    services.AddScoped<CreateStudent.IStudentRepository, StudentRepository>();
    services.AddScoped<GetStudentByEmail.IStudentRepository, StudentRepository>();
    services.AddScoped<VerifyStudentPassword.IStudentRepository, StudentRepository>();
    services.AddScoped<GetStudentById.IStudentRepository, StudentRepository>();
    services.AddScoped<DeleteStudentById.IStudentRepository, StudentRepository>();
    services.AddScoped<CheckAccess.IPermissionRepository, PermissionRepository>();
    services.AddScoped<AddAccess.IPermissionRepository, PermissionRepository>();
    services.AddScoped<GetCourses.ICourseRepository, CourseRepository>();
    services.AddScoped<GetCourseById.ICourseRepository, CourseRepository>();
    services.AddScoped<GetCoursesTags.ITagRepository, CourseTagRepository>();
    services.AddScoped<GetTagsByCourseId.ITagRepository, CourseTagRepository>();
    
    return services;
  }
}
