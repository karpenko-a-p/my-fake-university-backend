using Microsoft.AspNetCore.Diagnostics;

namespace Karpenko.University.Backend.API.Middlewares;

/// <summary>
/// Глобальный обработчик непредвиденных ошибок
/// </summary>
public sealed class ExceptionHandlingMiddleware : IExceptionHandler {
  /// <summary>
  /// Обработка ошибки
  /// </summary>
  public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken) {
    var response = httpContext.Response;
    
    response.StatusCode = StatusCodes.Status500InternalServerError;
    await response.WriteAsJsonAsync(new { exception.Message, response.StatusCode }, cancellationToken);
    
    return true;
  }
}
