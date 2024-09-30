using Karpenko.University.Backend.Application.Validation;
using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.GenerateJwtToken;

/// <summary>
/// Возможные результаты при регистрации пользователя
/// </summary>
public static class Results {
  /// <summary>
  /// Данные для создания аккаунта не переданы
  /// </summary>
  public sealed record EmptyData : IResult;
  
  /// <summary>
  /// Ошибка на этапе валидации данных
  /// </summary>
  public sealed record ValidationError(ValidationResult ValidationResult) : IResult;
  
  /// <summary>
  /// Токен успешно создан
  /// </summary>
  public sealed record TokenGenerated(string Token) : IResult;
}
