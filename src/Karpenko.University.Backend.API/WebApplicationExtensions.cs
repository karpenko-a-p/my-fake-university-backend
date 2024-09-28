namespace Karpenko.University.Backend.API;

/// <summary>
/// Методы расширения для web приложения
/// </summary>
internal static class WebApplicationExtensions {
  /// <summary>
  /// Подключение Swagger к конвейеру приложения
  /// </summary>
  internal static WebApplication UseConfiguredSwagger(this WebApplication app) {
    if (app.Environment.IsDevelopment()) {
      app.UseSwagger();
      app.UseSwaggerUI();
    }

    return app;
  } 
}
