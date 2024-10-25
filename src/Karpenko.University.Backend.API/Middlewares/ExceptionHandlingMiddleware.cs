using static System.Net.HttpStatusCode;
using Karpenko.University.Backend.API.Controllers;
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
    await response.WriteAsJsonAsync(
      new ErrorContract(InternalServerError.ToString(), exception.Message),
      cancellationToken);
    
    return true;
  }
}
