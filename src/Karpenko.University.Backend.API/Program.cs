using Karpenko.University.Backend.Application;
using Karpenko.University.Backend.Infrastructure;
using Karpenko.University.Backend.Persistence;
using Serilog;

namespace Karpenko.University.Backend.API;

/// <summary>
/// Главный класс программы
/// </summary>
public class Program {
  /// <summary>
  /// Точка входа в приложение
  /// </summary>
  public static void Main(string[] args) {
    var builder = WebApplication.CreateBuilder(args);
    ConfigureServices(builder);
    StartupApplication(builder.Build());
  }

  /// <summary>
  /// Добавление сервисов в DI контейнер
  /// </summary>
  private static void ConfigureServices(WebApplicationBuilder builder) {
    var services = builder.Services;

    // Добавление слоев приложения
    services.AddApplication();
    services.AddInfrastructure();
    services.AddPersistence();

    // Добавление логирования
    services.AddLogging();
    
    // Добавление конфигураций в di контейнер
    services.AddConfigurations(builder.Configuration);

    // Добавление аутентификации
    services.AddAuth(builder.Configuration);
    
    // Конфигурация контроллеров
    services.AddConfiguredControllers();
    
    // Глобальная обработка непредвиденных ошибок
    services.AddExceptionHandlingMiddleware();

    // Добавление поддержки Swagger
    services.AddSwagger(builder.Configuration);
  }

  /// <summary>
  /// Запуск приложения
  /// </summary>
  private static void StartupApplication(WebApplication app) {
    app.UseExceptionHandler(options => {});
    app.UseSerilogRequestLogging();
    app.UseConfiguredSwagger();
    app.UseAuthorization();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
  }
}
