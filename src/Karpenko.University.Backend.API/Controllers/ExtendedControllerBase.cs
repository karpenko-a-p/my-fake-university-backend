using System.Net;
using Microsoft.AspNetCore.Mvc;
using static Karpenko.University.Backend.Application.UseCases.GenerateJwtToken.Constants;

namespace Karpenko.University.Backend.API.Controllers;

/// <summary>
/// Расширение для базового класса контроллера
/// </summary>
public abstract class ExtendedControllerBase : ControllerBase {
  /// <summary>
  /// Результат с внутренней ошибкой сервера
  /// </summary>
  protected IActionResult InternalServerError(object? data) {
    return StatusCode((int)HttpStatusCode.InternalServerError, data);
  }

  /// <summary>
  /// Не удалось корректно обработать запрос
  /// </summary>
  protected IActionResult CantHandleRequest(string errorMessage = "Не удалось корректно обработать запрос") {
    return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorContract(
        nameof(CantHandleRequest),
        errorMessage));
  }
  
  /// <summary>
  /// Недостаточно прав
  /// </summary>
  protected IActionResult Forbidden(object? data) {
    return StatusCode((int)HttpStatusCode.Forbidden, data);
  }

  /// <summary>
  /// Получение идентификатора отправителя запроса, если авторизован
  /// </summary>
  /// <returns></returns>
  protected long? GetClaimId() {
    if (User.Identity?.IsAuthenticated is null or false)
      return null;
    
    var claimValue = User.Claims.FirstOrDefault(c => c.Type == IdClaimName)?.Value;
    
    if (claimValue is null)
      return null;

    return Convert.ToInt64(claimValue);
  }
}
