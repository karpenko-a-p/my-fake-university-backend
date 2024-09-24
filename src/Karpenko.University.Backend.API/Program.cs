using Karpenko.University.Backend.Application;

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
    
    // Конфигурация контроллеров
    services.AddControllers();
    
    // swagger
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
  }

  /// <summary>
  /// Запуск приложения
  /// </summary>
  private static void StartupApplication(WebApplication app) {
    if (app.Environment.IsDevelopment()) {
      app.UseSwagger();
      app.UseSwaggerUI();
    }

    app.UseAuthorization();
    app.MapControllers();

    app.Run();
  }
}
