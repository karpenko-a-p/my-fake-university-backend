using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.Validation;

/// <summary>
/// Результаты валидации
/// </summary>
public static class Results {
  /// <summary>
  /// Ошибка во время валидации
  /// </summary>
  public sealed record ValidationFailure(ValidationResult ValidationResult) : IResult;
}
