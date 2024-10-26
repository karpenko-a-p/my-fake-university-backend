using System.Net;
using Microsoft.AspNetCore.Mvc;

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
}
