using System.Text.RegularExpressions;

namespace Karpenko.University.Backend.Application.Validation;

/// <summary>
/// Валидатор для строк
/// </summary>
public sealed class StringValidator(string propertyName, string? value, ICollection<ValidationError> validationErrors) {
  /// <summary>
  /// Сообщение об ошибке при проверке на null
  /// </summary>
  public const string NotNullErrorMessage = "Значение не может быть равно null";

  /// <summary>
  /// Сообщение об ошибке при проверке на пустоту
  /// </summary>
  public const string NotEmptyErrorMessage = "Значение не может быть пустым";

  /// <summary>
  /// Сообщение об ошибке при проверке на длину (Строка меньше определенной длинны)
  /// </summary>
  public const string LengthLowerThenErrorMessage = "Значение должно быть короче {0} символов";

  /// <summary>
  /// Сообщение об ошибке при проверке на длину (Строка меньше или равна определенной длине)
  /// </summary>
  public const string LengthLowerThenOrEqualErrorMessage = "Значение должно быть короче или равно {0} символам";

  /// <summary>
  /// Сообщение об ошибке при проверке на длину (Строка больше определенной длинны)
  /// </summary>
  public const string LengthGreaterThenErrorMessage = "Значение должно быть длиннее {0} символов";

  /// <summary>
  /// Сообщение об ошибке при проверке на длину (Строка больше или равна определенной длине)
  /// </summary>
  public const string LengthGreaterThenOrEqualErrorMessage = "Значение должно быть длиннее или равно {0} символам";

  /// <summary>
  /// Сообщение об ошибке при проверке равенства определенному значению
  /// </summary>
  public const string EqualErrorMessage = "Значение должно быть равно \"{0}\"";

  /// <summary>
  /// Сообщение об ошибке при проверке не равенства определенному значению
  /// </summary>
  public const string NotEqualErrorMessage = "Значение не должно быть равно \"{0}\"";

  /// <summary>
  /// Сообщение об ошибке при проверке на соответствие формату
  /// </summary>
  public const string MatchErrorMessage = "Значение не соответствует корректному формату";

  /// <summary>
  /// Сообщение об ошибке при проверке на не соответствие формату
  /// </summary>
  public const string NotMatchErrorMessage = "Значение соответствует некорректному формату";

  /// <summary>
  /// Строка не равна null
  /// </summary>
  public StringValidator NotNull(string errorMessage = NotNullErrorMessage) {
    if (value is null)
      validationErrors.Add(new(propertyName, errorMessage));

    return this;
  }

  /// <summary>
  /// Строка не пустая
  /// </summary>
  public StringValidator NotEmpty(string errorMessage = NotEmptyErrorMessage) {
    if (value is null || value == "")
      validationErrors.Add(new(propertyName, errorMessage));

    return this;
  }

  /// <summary>
  /// Строка меньше определенной длинны
  /// </summary>
  public StringValidator LengthLowerThen(int compareValue, string? errorMessage = null) {
    if (value is null || value.Length >= compareValue)
      validationErrors.Add(new(propertyName, errorMessage ?? string.Format(LengthLowerThenErrorMessage, compareValue)));

    return this;
  }

  /// <summary>
  /// Строка меньше или равна определенной длине
  /// </summary>
  public StringValidator LengthLowerThenOrEqual(int compareValue, string? errorMessage = null) {
    if (value is null || value.Length > compareValue)
      validationErrors.Add(new(propertyName, errorMessage ?? string.Format(LengthLowerThenOrEqualErrorMessage, compareValue)));

    return this;
  }

  /// <summary>
  /// Строка больше определенной длинны
  /// </summary>
  public StringValidator LengthGreaterThen(int compareValue, string? errorMessage = null) {
    if (value is null || value.Length <= compareValue)
      validationErrors.Add(new(propertyName, errorMessage ?? string.Format(LengthGreaterThenErrorMessage, compareValue)));

    return this;
  }

  /// <summary>
  /// Строка больше или равна определенной длине
  /// </summary>
  public StringValidator LengthGreaterThenOrEqual(int compareValue, string? errorMessage = null) {
    if (value is null || value.Length < compareValue)
      validationErrors.Add(new(propertyName, errorMessage ?? string.Format(LengthGreaterThenOrEqualErrorMessage, compareValue)));

    return this;
  }

  /// <summary>
  /// Строка равна определенной строке
  /// </summary>
  public StringValidator Equal(string compareValue, string? errorMessage = null) {
    if (value != compareValue)
      validationErrors.Add(new(propertyName, errorMessage ?? string.Format(EqualErrorMessage, compareValue)));

    return this;
  }

  /// <summary>
  /// Строка не равна определенной строке
  /// </summary>
  public StringValidator NotEqual(string compareValue, string? errorMessage = null) {
    if (value == compareValue)
      validationErrors.Add(new(propertyName, errorMessage ?? string.Format(NotEqualErrorMessage, compareValue)));

    return this;
  }

  /// <summary>
  /// Строка соответствует регулярному выражению
  /// </summary>
  public StringValidator Match(Regex compareValue, string errorMessage = MatchErrorMessage) {
    if (value is null || !compareValue.IsMatch(value))
      validationErrors.Add(new(propertyName, errorMessage));

    return this;
  }

  /// <summary>
  /// Строка не соответствует регулярному выражению
  /// </summary>
  public StringValidator NotMatch(Regex compareValue, string errorMessage = NotMatchErrorMessage) {
    if (value is null)
      return this;

    if (compareValue.IsMatch(value))
      validationErrors.Add(new(propertyName, errorMessage));

    return this;
  }

  /// <summary>
  /// Кастомные условия для строки
  /// </summary>
  public StringValidator Must(Func<string?, bool> predicate, string errorMessage) {
    if (!predicate(value))
      validationErrors.Add(new(propertyName, errorMessage));

    return this;
  }
}
