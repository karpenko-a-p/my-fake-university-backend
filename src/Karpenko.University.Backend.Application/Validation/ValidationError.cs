namespace Karpenko.University.Backend.Application.Validation;

/// <summary>
/// Ошибка валидации
/// </summary>
/// <param name="PropertyName">Название поля с ошибкой</param>
/// <param name="ErrorMessage">Сообщение об ошибке</param>
public sealed record ValidationError(
  string PropertyName,
  string ErrorMessage);
