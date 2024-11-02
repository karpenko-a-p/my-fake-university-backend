using Karpenko.University.Backend.Domain.CourseComment;

namespace Karpenko.University.Backend.Application.UseCases.GetCommentsByCourseId;

/// <summary>
/// ДТО комментария под курсом
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Content">Содержание комментария</param>
/// <param name="Quality">Оценка автора комментария курсу</param>
/// <param name="CreationDate">Дата написания комментарий</param>
/// <param name="Author">Данные втора комментария</param>
public sealed record CommentWithAuthorDto(
  long Id,
  string Content,
  CourseQuality Quality,
  DateTime CreationDate,
  AuthorDto? Author);

/// <summary>
/// DTO данных автора комментария
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Имя</param>
/// <param name="AvatarUrl">Ссылка на фото</param>
public sealed record AuthorDto(
  long Id,
  string Name,
  string? AvatarUrl);
