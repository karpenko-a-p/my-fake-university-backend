using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.CheckAccess;

/// <summary>
/// Результаты сценария проверки прав доступа
/// </summary>
public static class Results {
  /// <summary>
  /// Есть доступ
  /// </summary>
  public sealed record HasAccess : IResult;
  
  /// <summary>
  /// Нет доступа
  /// </summary>
  public sealed record NoAccess : IResult;
}
