using Karpenko.University.Backend.Application.Validation;
using Karpenko.University.Backend.Core.ResultPattern;
using Karpenko.University.Backend.Domain.Student;

namespace Karpenko.University.Backend.Application.UseCases.CreateStudent;

/// <summary>
/// Возможные результаты при создании аккаунта студента
/// </summary>
public static class Results {
  /// <summary>
  /// Аккаунт студента был создан
  /// </summary>
  public sealed record StudentCreated(StudentModel StudentModel) : IResult;

  /// <summary>
  /// Ошибка валидации данных для создания аккаунта студента
  /// </summary>
  public sealed record ValidationError(ValidationResult ValidationResult) : IResult;

  /// <summary>
  /// Аккаунт студента с такой почтой уже существует
  /// </summary>
  public sealed record StudentAlreadyExists : IResult;
}
