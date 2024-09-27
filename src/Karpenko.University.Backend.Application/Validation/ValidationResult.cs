namespace Karpenko.University.Backend.Application.Validation;

/// <summary>
/// Результат валидации модели
/// </summary>
/// <param name="ValidationErrors">Список ошибок валидации</param>
public sealed record ValidationResult(ICollection<ValidationError> ValidationErrors) {
  /// <summary>
  /// Модель не содержит ошибок валидации
  /// </summary>
  public bool IsSuccess => ValidationErrors.Count == 0;

  /// <summary>
  /// Модель содержит ошибки валидации
  /// </summary>
  public bool IsFailure => ValidationErrors.Count != 0;
};
