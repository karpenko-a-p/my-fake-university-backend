using System.Numerics;

namespace Karpenko.University.Backend.Application.Validation;

/// <summary>
/// Абстрактный валидатор
/// </summary>
/// <typeparam name="TModel">Валидируемая модель</typeparam>
public abstract class AbstractValidator<TModel> : IValidator<TModel> {
  /// <summary>
  /// Список ошибок валидации
  /// </summary>
  protected ICollection<ValidationError> ValidationErrors => [];

  /// <inheritdoc />
  public virtual ValidationResult Validate(TModel model) {
    ValidateModel(model);
    return new ValidationResult(ValidationErrors);
  }

  /// <summary>
  /// Валидация модели
  /// </summary>
  protected abstract void ValidateModel(TModel model);

  /// <summary>
  /// Валидатора для строк
  /// </summary>
  protected StringValidator StringValidator(string propertyName, string value) => new(propertyName, value, ValidationErrors);
  
  /// <summary>
  /// Валидатор для чисел
  /// </summary>
  protected NumberValidator<TNumber> NumberValidator<TNumber>(string propertyName, TNumber value) where TNumber : INumber<TNumber> => new(propertyName, value, ValidationErrors);
}
