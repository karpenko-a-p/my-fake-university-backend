using Karpenko.University.Backend.Domain.CourseComment;

namespace Karpenko.University.Backend.Application.UseCases.CreateComment;

/// <summary>
/// Данные для создания нового комментария в БД
/// </summary>
/// <param name="CourseId">Идентификатор курса</param>
/// <param name="StudentId">Идентификатор студента</param>
/// <param name="Content">Содержание комментария</param>
/// <param name="Quality">Оценка автора комментария курсу</param>
public sealed record CreateCommentDto(
  long CourseId,
  long StudentId,
  string Content,
  CourseQuality Quality);
