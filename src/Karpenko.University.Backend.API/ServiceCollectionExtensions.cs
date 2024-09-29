using System.Net.Mime;
using System.Text;
using Karpenko.University.Backend.API.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;
using Serilog;

namespace Karpenko.University.Backend.API;

/// <summary>
/// Методы расширения для коллекции сервисов для запуска приложения
/// </summary>
internal static class ServiceCollectionExtensions {
  /// <summary>
  /// Конфигурация контроллеров
  /// </summary>
  internal static IServiceCollection AddConfiguredControllers(this IServiceCollection services) {
    services
      .AddControllers(options => {
        options.Filters.Add(new ConsumesAttribute(MediaTypeNames.Application.Json));
        options.Filters.Add(new ProducesAttribute(MediaTypeNames.Application.Json));
      })
      .ConfigureApiBehaviorOptions(options => {
        options.SuppressModelStateInvalidFilter = true;
        options.DisableImplicitFromServicesParameters = true;
        options.SuppressInferBindingSourcesForParameters = true;
        options.SuppressMapClientErrors = true;
        options.SuppressConsumesConstraintForFormFileParameters = true;
      })
      .AddNewtonsoftJson(options => {
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
      });

    return services;
  }

  /// <summary>
  /// Добавление поддержки Swagger
  /// </summary>
  internal static IServiceCollection AddSwagger(this IServiceCollection services) {
    services.AddSwaggerGenNewtonsoftSupport();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(options => {
      string xmlPath = Path.Combine(AppContext.BaseDirectory, "Karpenko.University.Backend.API.xml");
      options.IncludeXmlComments(xmlPath);
    });

    return services;
  }

  /// <summary>
  /// Глобальная обработка непредвиденных ошибок
  /// </summary>
  internal static IServiceCollection AddExceptionHandlingMiddleware(this IServiceCollection services) {
    services.AddExceptionHandler<ExceptionHandlingMiddleware>();

    return services;
  }

  /// <summary>
  /// Добавление логирования
  /// </summary>
  internal static IServiceCollection AddLogging(this IServiceCollection services) {
    services.AddSerilog((_, options) => {
      options
        .WriteTo.Console()
        .WriteTo.File("logs/log-.txt",
          rollingInterval: RollingInterval.Day,
          rollOnFileSizeLimit: true,
          fileSizeLimitBytes: 100 * 1024 * 1024); // 100Mb
    });

    return services;
  }

  /// <summary>
  /// Добавление аутентификации
  /// </summary>
  internal static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration) {
    var jwtIssuer = configuration["JWT:Issuer"]!;
    var jwtAudience = configuration["JWT:Audience"]!;
    var jwtSecret = configuration["JWT:Secret"]!;

    services
      .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          ValidAudience = jwtAudience,
          ValidIssuer = jwtIssuer,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
        };
      });

    return services;
  }
}
