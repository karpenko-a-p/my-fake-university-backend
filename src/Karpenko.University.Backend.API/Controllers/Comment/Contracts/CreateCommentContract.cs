using Karpenko.University.Backend.Domain.CourseComment;

namespace Karpenko.University.Backend.API.Controllers.Comment.Contracts;

/// <summary>
/// Контракт данных для создания комментария к курсу
/// </summary>
/// <param name="CourseId">ЯИдентификатору курса, которому будет принадлежать комментарий</param>
/// <param name="Content">Содержание комментария</param>
/// <param name="Quality">Оценка автора комментария курсу</param>
public sealed record CreateCommentContract(
  long? CourseId,
  string? Content,
  CourseQuality? Quality);
