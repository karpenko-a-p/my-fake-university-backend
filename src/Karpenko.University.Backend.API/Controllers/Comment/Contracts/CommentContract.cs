using Karpenko.University.Backend.Domain.CourseComment;

namespace Karpenko.University.Backend.API.Controllers.Comment.Contracts;

/// <summary>
/// Контракт для модели комментария
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Content">Содержание комментария</param>
/// <param name="Quality">Оценка автора комментария курсу</param>
/// <param name="CreationDate">Дата написания комментарий</param>
public sealed record CommentContract(
  long Id,
  string Content,
  CourseQuality Quality,
  DateTime CreationDate
) {
  /// <summary>
  /// Преобразование модели комментария к контракту
  /// </summary>
  public CommentContract(CourseCommentModel comment) : this(
    comment.Id,
    comment.Content,
    comment.Quality,
    comment.CreationDate) {}
}
