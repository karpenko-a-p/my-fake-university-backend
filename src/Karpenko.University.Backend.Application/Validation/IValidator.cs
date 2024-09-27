namespace Karpenko.University.Backend.Application.Validation;

/// <summary>
/// Интерфейс валидатора
/// </summary>
/// <typeparam name="TModel">Валидируемая модель</typeparam>
public interface IValidator<in TModel> {
  /// <summary>
  /// Валидация модели
  /// </summary>
  ValidationResult Validate(TModel model);
}
