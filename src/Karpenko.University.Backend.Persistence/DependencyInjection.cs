using Karpenko.University.Backend.Persistence.Database;
using Karpenko.University.Backend.Persistence.Database.Contexts;
using CreateStudent = Karpenko.University.Backend.Application.UseCases.CreateStudent;
using GetStudentByExpression = Karpenko.University.Backend.Application.UseCases.GetStudentByExpression;
using VerifyStudentPassword = Karpenko.University.Backend.Application.UseCases.VerifyStudentPassword;
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
    services.AddDbContextPool<PostgresDbContext>(options => {
      options.UseNpgsql(configuration.GetConnectionString("Postgres"), npgOptions => {
        npgOptions.EnableRetryOnFailure(
          maxRetryCount: 3);
        npgOptions.MigrationsHistoryTable(
          tableName: Tables.MigrationsHistory,
          schema: Schemas.UniversityBackend);
      });
    });
    
    // Репозитории
    services.AddScoped<CreateStudent.IStudentRepository, StudentRepository>();
    services.AddScoped<GetStudentByExpression.IStudentRepository, StudentRepository>();
    services.AddScoped<VerifyStudentPassword.IStudentRepository, StudentRepository>();
    
    return services;
  }
}
