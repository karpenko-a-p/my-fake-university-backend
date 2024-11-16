using System.Net.Mime;
using System.Text;
using Karpenko.University.Backend.API.Controllers;
using Karpenko.University.Backend.API.Middlewares;
using Karpenko.University.Backend.Application.Caching;
using Karpenko.University.Backend.Application.UseCases.GenerateJwtToken;
using Karpenko.University.Backend.Application.UseCases.GetCourseVideo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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
  internal static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration) {
    services.AddSwaggerGenNewtonsoftSupport();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(options => {
      // файл с документацией xml
      string xmlPath = Path.Combine(AppContext.BaseDirectory, "Karpenko.University.Backend.API.xml");
      options.IncludeXmlComments(xmlPath);

      // авторизация
      options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme {
        Description = "JWT токен в куках",
        Name = configuration["JWT:CookieName"]!,
        In = ParameterLocation.Cookie,
        Type = SecuritySchemeType.ApiKey
      });

      options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
          new OpenApiSecurityScheme {
            Reference = new OpenApiReference {
              Type = ReferenceType.SecurityScheme,
              Id = JwtBearerDefaults.AuthenticationScheme
            }
          },
          []
        }
      });
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
    var jwtCookieName = configuration["JWT:CookieName"]!;

    services
      .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options => {
        // Настройка параметров для валидации
        options.TokenValidationParameters = new TokenValidationParameters {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          ValidAudience = jwtAudience,
          ValidIssuer = jwtIssuer,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
        };

        options.Events = new JwtBearerEvents {
          // Получение токена из куки
          OnMessageReceived = context => {
            if (context.Request.Cookies.ContainsKey(jwtCookieName)) {
              context.Token = context.Request.Cookies[jwtCookieName];
            }

            return Task.CompletedTask;
          },
          // Токен отсутствует или недействителен
          OnChallenge = async (context) => {
            context.HandleResponse();
            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.HttpContext.Response.WriteAsJsonAsync(new ErrorContract(
              ErrorCode: "Unauthorized",
              ErrorMessage: "Не авторизован"));
          }
        };
      });

    return services;
  }

  /// <summary>
  /// Добавление конфигураций в di контейнер
  /// </summary>
  internal static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration) {
    services.Configure<AuthOptions>(configuration.GetSection("Jwt"));
    services.Configure<VideoContentOptions>(configuration.GetSection("VideoContent"));
    services.Configure<CacheOptions>(config => {
      config.ConnectionString = configuration.GetConnectionString("Redis") ?? string.Empty;
    });

    return services;
  }
}
