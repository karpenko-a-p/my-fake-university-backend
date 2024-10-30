using Karpenko.University.Backend.Core.ResultPattern;
using Karpenko.University.Backend.Domain.CourseComment;

namespace Karpenko.University.Backend.Application.UseCases.DeleteCommentById;

/// <summary>
/// Возможные результаты сценария удаления комментария
/// </summary>
public static class Results {
  /// <summary>
  /// Комментарий не найден
  /// </summary>
  public sealed record NotFound : IResult;

  /// <summary>
  /// Комментарий успешно удален
  /// </summary>
  public sealed record Deleted(CourseCommentModel Comment) : IResult;
}
