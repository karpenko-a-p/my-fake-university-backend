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
using GetCoursesByTagId = Karpenko.University.Backend.Application.UseCases.GetCoursesByTagId;
using CreateComment = Karpenko.University.Backend.Application.UseCases.CreateComment;
using DeleteCommentById = Karpenko.University.Backend.Application.UseCases.DeleteCommentById;
using GetCommentsByAuthorId = Karpenko.University.Backend.Application.UseCases.GetCommentsByAuthorId;
using GetCommentsByCourseId = Karpenko.University.Backend.Application.UseCases.GetCommentsByCourseId;
using CreateOrder = Karpenko.University.Backend.Application.UseCases.CreateOrder;
using GetOrderById = Karpenko.University.Backend.Application.UseCases.GetOrderById;
using DeleteOrderById = Karpenko.University.Backend.Application.UseCases.DeleteOrderById;
using PayOrderById = Karpenko.University.Backend.Application.UseCases.PayOrderById;
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
      options
        .UseNpgsql(configuration.GetConnectionString("Postgres"), npgOptions => {
          npgOptions.MigrationsHistoryTable(
            tableName: Tables.MigrationsHistory,
            schema: Schemas.UniversityBackend);
        })
        .UseSnakeCaseNamingConvention();
    });

    // Репозитории
    services.AddScoped<CreateStudent.IStudentRepository, StudentRepository>();
    services.AddScoped<CreateStudent.IPermissionRepository, PermissionRepository>();
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
    services.AddScoped<GetCoursesByTagId.ICourseRepository, CourseRepository>();
    services.AddScoped<CreateComment.ICourseRepository, CourseRepository>();
    services.AddScoped<CreateComment.ICommentRepository, CommentRepository>();
    services.AddScoped<DeleteCommentById.ICommentRepository, CommentRepository>();
    services.AddScoped<GetCommentsByAuthorId.ICommentRepository, CommentRepository>();
    services.AddScoped<GetCommentsByCourseId.ICommentRepository, CommentRepository>();
    services.AddScoped<CreateOrder.IOrderRepository, OrderRepository>();
    services.AddScoped<GetOrderById.IOrderRepository, OrderRepository>();
    services.AddScoped<DeleteOrderById.IOrderRepository, OrderRepository>();
    services.AddScoped<PayOrderById.IOrderRepository, OrderRepository>();

    return services;
  }
}
