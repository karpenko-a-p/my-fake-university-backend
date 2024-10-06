using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.DeleteStudentById;

/// <summary>
/// Результаты сценария удаления аккаунта студента по идентификатору
/// </summary>
public static class Results {
  /// <summary>
  /// Успешное удаление
  /// </summary>
  public sealed record Deleted : IResult;

  /// <summary>
  /// Запись студента не удалена
  /// </summary>
  public sealed record NotDeleted : IResult;
}
