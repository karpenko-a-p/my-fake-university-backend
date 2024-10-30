using Karpenko.University.Backend.Application.Validation;
using Karpenko.University.Backend.Infrastructure.Caching;
using Karpenko.University.Backend.Infrastructure.Services;
using Karpenko.University.Backend.Infrastructure.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CreateStudent = Karpenko.University.Backend.Application.UseCases.CreateStudent;
using GenerateJwtToken = Karpenko.University.Backend.Application.UseCases.GenerateJwtToken;
using VerifyStudentPassword = Karpenko.University.Backend.Application.UseCases.VerifyStudentPassword;
using GetCoursesTags = Karpenko.University.Backend.Application.UseCases.GetCoursesTags;
using GetCourses = Karpenko.University.Backend.Application.UseCases.GetCourses;
using GetCoursesByTagId = Karpenko.University.Backend.Application.UseCases.GetCoursesByTagId;
using CheckAccess = Karpenko.University.Backend.Application.UseCases.CheckAccess;
using CreateComment = Karpenko.University.Backend.Application.UseCases.CreateComment;
using AddAccess = Karpenko.University.Backend.Application.UseCases.AddAccess;

namespace Karpenko.University.Backend.Infrastructure;

/// <summary>
/// Внедрение слоя Infrastructure
/// </summary>
public static class DependencyInjection {
  /// <summary>
  /// Метод для добавления слоя к списку сервисов
  /// </summary>
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
    // Распределенный кэш
    services.AddStackExchangeRedisCache(options => {
      options.Configuration = configuration.GetConnectionString("Redis");
    });
    services.AddSingleton<GetCourses.ICacheService, CourseCacheService>();
    services.AddSingleton<GetCoursesTags.ICacheService, CourseTagCacheService>();
    services.AddSingleton<GetCoursesByTagId.ICacheService, CourseCacheService>();

    // Сервисы
    services.AddSingleton<CreateStudent.IPasswordService, PasswordService>();
    services.AddSingleton<VerifyStudentPassword.IPasswordService, PasswordService>();
    services.AddSingleton<GenerateJwtToken.IJwtService, JwtService>();

    // Валидаторы
    services.AddSingleton<IValidator<CreateStudent.EntryData>, CreateStudentEntryDataValidator>();
    services.AddSingleton<IValidator<GenerateJwtToken.EntryData>, GenerateJwtTokenEntryDataValidator>();
    services.AddSingleton<IValidator<VerifyStudentPassword.EntryData>, VerifyStudentPasswordEntryDataValidation>();
    services.AddSingleton<IValidator<CheckAccess.EntryData>, CheckAccessEntryDataValidator>();
    services.AddSingleton<IValidator<CreateComment.EntryData>, CreateCommentEntryDataValidator>();
    services.AddSingleton<IValidator<AddAccess.EntryData>, AddAccessEntryDataValidator>();

    return services;
  }
}
