namespace Karpenko.Filmogram.Backend.API;

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
    builder.Services.AddControllers();
    
    // swagger
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
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
