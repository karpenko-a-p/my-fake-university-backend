using System.Numerics;

namespace Karpenko.University.Backend.Application.Validation;

/// <summary>
/// Валидатор для числовых типов данных
/// </summary>
public sealed class NumberValidator<TNumber>(string propertyName, TNumber? value, ICollection<ValidationError> validationErrors) where TNumber : INumber<TNumber> {
  /// <summary>
  /// Сообщение об ошибке при проверке на null
  /// </summary>
  public const string NotNullErrorMessage = "Число не может быть равно null";

  /// <summary>
  /// Сообщение об ошибке при проверке на пустоту
  /// </summary>
  public const string NotEmptyErrorMessage = "Число не может быть пустым";
  
  /// <summary>
  /// Сообщение об ошибке при сравнении (Число больше определенного значения)
  /// </summary>
  public const string GreaterThenErrorMessage = "Число должно быть больше {0}";
  
  /// <summary>
  /// Сообщение об ошибке при сравнении (Число больше определенного значения или равно ему)
  /// </summary>
  public const string GreaterThenOrEqualErrorMessage = "Число должно быть больше или равно {0}";
  
  /// <summary>
  /// Сообщение об ошибке при сравнении (Число больше определенного значения)
  /// </summary>
  public const string LowerThenErrorMessage = "Число должно быть меньше {0}";
  
  /// <summary>
  /// Сообщение об ошибке при сравнении (Число больше определенного значения или равно ему)
  /// </summary>
  public const string LowerThenOrEqualErrorMessage = "Число должно быть меньше или равно {0}";
  
  /// <summary>
  /// Сообщение об ошибке при неравенстве определенному значение
  /// </summary>
  public const string EqualErrorMessage = "Число должно быть равно {0}";
  
  /// <summary>
  /// Сообщение об ошибке при равенстве определенному значение
  /// </summary>
  public const string NotEqualErrorMessage = "Число не должно быть равно {0}";
  
  /// <summary>
  /// Сообщение об ошибке при несоответствии числа определенному перечислению
  /// </summary>
  public const string IsDefinedInErrorMessage = "Недопустимый формат числа";

  /// <summary>
  /// Число не равно null
  /// </summary>
  public NumberValidator<TNumber> NotNull(string errorMessage = NotNullErrorMessage) {
    if (value is null)
      validationErrors.Add(new (propertyName, errorMessage));

    return this;
  }
  
  /// <summary>
  /// Число не равно дефолтному значению
  /// </summary>
  public NumberValidator<TNumber> NotEmpty(string errorMessage = NotEmptyErrorMessage) {
    if (value == default)
      validationErrors.Add(new (propertyName, errorMessage));

    return this;
  }

  /// <summary>
  /// Число больше определенного значения 
  /// </summary>
  public NumberValidator<TNumber> GreaterThen(TNumber compareValue, string? errorMessage = null) {
    if (value is null || value <= compareValue)
      validationErrors.Add(new (propertyName, errorMessage ?? string.Format(GreaterThenErrorMessage, compareValue)));

    return this;
  }
  
  /// <summary>
  /// Число больше определенного значения или равно ему
  /// </summary>
  public NumberValidator<TNumber> GreaterThenOrEqual(TNumber compareValue, string? errorMessage = null) {
    if (value is null || value < compareValue)
      validationErrors.Add(new (propertyName, errorMessage ?? string.Format(GreaterThenOrEqualErrorMessage, compareValue)));

    return this;
  }
  
  /// <summary>
  /// Число меньше определенного значения 
  /// </summary>
  public NumberValidator<TNumber> LowerThen(TNumber compareValue, string? errorMessage = null) {
    if (value is null || value >= compareValue)
      validationErrors.Add(new (propertyName, errorMessage ?? string.Format(LowerThenErrorMessage, compareValue)));

    return this;
  }
  
  /// <summary>
  /// Число меньше определенного значения или равно ему
  /// </summary>
  public NumberValidator<TNumber> LowerThenOrEqual(TNumber compareValue, string? errorMessage = null) {
    if (value is null || value > compareValue)
      validationErrors.Add(new (propertyName, errorMessage ?? string.Format(LowerThenOrEqualErrorMessage, compareValue)));

    return this;
  }

  /// <summary>
  /// Определено ли число в перечислении
  /// </summary>
  public NumberValidator<TNumber> IsDefinedIn<TEnum>(string? errorMessage = null) where TEnum : Enum {
    if (value is null || !Enum.IsDefined(typeof(TEnum), value))
      validationErrors.Add(new (propertyName, errorMessage ?? IsDefinedInErrorMessage));

    return this;
  }

  /// <summary>
  /// Число равно определенному значению
  /// </summary>
  public NumberValidator<TNumber> Equal(TNumber compareValue, string? errorMessage = null) {
    if (value != compareValue)
      validationErrors.Add(new (propertyName, errorMessage ?? string.Format(EqualErrorMessage, compareValue)));

    return this;
  }
  
  /// <summary>
  /// Число не равно определенному значению
  /// </summary>
  public NumberValidator<TNumber> NotEqual(TNumber compareValue, string? errorMessage = null) {
    if (value == compareValue)
      validationErrors.Add(new (propertyName, errorMessage ?? string.Format(NotEqualErrorMessage, compareValue)));

    return this;
  }
  
  /// <summary>
  /// Кастомные условия для числа
  /// </summary>
  public NumberValidator<TNumber> Must(Func<TNumber?, bool> predicate, string errorMessage) {
    if (!predicate(value))
      validationErrors.Add(new (propertyName, errorMessage));

    return this;
  }
}
