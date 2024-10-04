using Karpenko.University.Backend.Application.Validation;
using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.VerifyStudentPassword;

/// <summary>
/// Возможные результаты сценария верификации пароля студента
/// </summary>
public static class Results {
  /// <summary>
  /// Ошибка валидации входных данных
  /// </summary>
  public sealed record ValidationError(ValidationResult ValidationResult) : IResult;

  /// <summary>
  /// Студент с такой почтой не существует
  /// </summary>
  public sealed record StudentNotFound : IResult;

  /// <summary>
  /// Пароли не совпали
  /// </summary>
  public sealed record PasswordsDontMatch : IResult;

  /// <summary>
  /// Пароль верифицирован
  /// </summary>
  public sealed record PasswordVerified : IResult;
}
