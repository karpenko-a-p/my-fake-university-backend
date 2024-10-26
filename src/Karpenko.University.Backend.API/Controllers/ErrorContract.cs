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
  public static ErrorContract ValidationError(ValidationResult validationResult, string errorMessage = "Ошибка на этапе валидации модели") => new(
    nameof(ValidationError),
    errorMessage,
    validationResult.ValidationErrors);
  
  /// <summary>
  /// Ошибка по причине наличия одного экземпляра
  /// </summary>
  public static ErrorContract AlreadyExists(string errorMessage = "Нельзя создать более одного экземпляра", object? details = null) => new(
    nameof(AlreadyExists),
    errorMessage,
    details);

  /// <summary>
  /// Ошибка по причине некорректного формата данных
  /// </summary>
  public static ErrorContract BadRequest(string errorMessage = "Некорректный формат данных", object? details = null) => new(
    nameof(BadRequest),
    errorMessage,
    details);
  
  /// <summary>
  /// Ошибка по причине ненайденных данных
  /// </summary>
  public static ErrorContract NotFound(string errorMessage = "Не найдено", object? details = null) => new(
    nameof(NotFound),
    errorMessage,
    details);

  /// <summary>
  /// Ошибка по причине отсутствия прав
  /// </summary>
  public static ErrorContract Forbidden(string errorMessage = "Недостаточно прав", object? details = null) => new(
    nameof(Forbidden),
    errorMessage,
    details);
}
