using Karpenko.University.Backend.Application.Validation;

namespace Karpenko.University.Backend.API.Controllers;

/// <summary>
/// Контракт ошибки
/// </summary>
/// <param name="ErrorCode">Код ошибки</param>
/// <param name="ErrorMessage">Сообщение ошибки</param>
/// <param name="Details">Детали ошибки</param>
public record ErrorContract(
  string ErrorCode,
  string ErrorMessage,
  object? Details = null
) {
  /// <summary>
  /// Ошибка по причине ошибки валидации
  /// </summary>
  public static ErrorContract ValidationError(ValidationResult validationResult) => new(
    "ValidationError",
    "Ошибка на этапе валидации модели",
    validationResult.ValidationErrors);
};
