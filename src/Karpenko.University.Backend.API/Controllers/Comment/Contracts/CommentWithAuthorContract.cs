using Karpenko.University.Backend.Application.UseCases.GetCommentsByCourseId;
using Karpenko.University.Backend.Domain.CourseComment;

namespace Karpenko.University.Backend.API.Controllers.Comment.Contracts;

/// <summary>
/// Контракт комментария под курсом
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Content">Содержание комментария</param>
/// <param name="Quality">Оценка автора комментария курсу</param>
/// <param name="CreationDate">Дата написания комментарий</param>
/// <param name="Author">Данные втора комментария</param>
public record CommentWithAuthorContract(
  long Id,
  string Content,
  CourseQuality Quality,
  DateTime CreationDate,
  AuthorContract? Author
) {
  /// <summary>
  /// Приведение DTO комментария к котракту
  /// </summary>
  public CommentWithAuthorContract(CommentWithAuthorDto commentWithAuthorDto) : this(
    commentWithAuthorDto.Id,
    commentWithAuthorDto.Content,
    commentWithAuthorDto.Quality,
    commentWithAuthorDto.CreationDate,
    commentWithAuthorDto.Author is not null
      ? new AuthorContract(commentWithAuthorDto.Author)
      : null) {}
}

/// <summary>
/// Контракт данных автора комментария
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Имя</param>
/// <param name="AvatarUrl">Ссылка на фото</param>
public sealed record AuthorContract(
  long Id,
  string Name,
  string? AvatarUrl
) {
  /// <summary>
  /// Приведение DTO автора комментария к контракту
  /// </summary>
  public AuthorContract(AuthorDto authorDto) : this(
    authorDto.Id,
    authorDto.Name,
    authorDto.AvatarUrl) {}
}
