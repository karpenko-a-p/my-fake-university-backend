using Karpenko.University.Backend.Core.ResultPattern;
using Karpenko.University.Backend.Domain.CourseComment;

namespace Karpenko.University.Backend.Application.UseCases.CreateComment;

/// <summary>
/// Результаты для сценария создания нового комментария
/// </summary>
public static class Results {
  /// <summary>
  /// Коммент создан
  /// </summary>
  public sealed record Created(CourseCommentModel Comment) : IResult;
  
  /// <summary>
  /// Курс с переданным идентификатором не существует
  /// </summary>
  public sealed record CourseNotFound : IResult;
}
