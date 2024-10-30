using System.Net.Mime;
using Karpenko.University.Backend.API.Controllers.Comment.Contracts;
using Karpenko.University.Backend.Application.Pagination;
using Karpenko.University.Backend.Domain.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CheckAccess = Karpenko.University.Backend.Application.UseCases.CheckAccess;
using CreateComment = Karpenko.University.Backend.Application.UseCases.CreateComment;
using Results = Karpenko.University.Backend.Application.Validation.Results;

namespace Karpenko.University.Backend.API.Controllers.Comment;

/// <summary>
/// Контроллер для работы комментариями
/// </summary>
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[Tags("api/comment/v1")]
[Route("api/comment/v1")]
public sealed class CommentController : ExtendedControllerBase {
  /// <summary>
  /// Получение комментариев определенного курса
  /// </summary>
  [HttpGet("by-course/{courseId:long:min(0)}")]
  public async Task<IActionResult> GetCommentsByCourseIdAsync(
    [FromRoute(Name = "courseId")] long courseId,
    [FromQuery] PaginationModel pagination,
    CancellationToken cancellationToken
  ) {
    return Ok();
  }

  /// <summary>
  /// Получение комментариев написанных определенным человеком
  /// </summary>
  [HttpGet("by-owner/{ownerId:long:min(0)}")]
  public async Task<IActionResult> GetCommentsByOwnerIdAsync(
    [FromRoute(Name = "ownerId")] long ownerId,
    [FromQuery] PaginationModel pagination,
    CancellationToken cancellationToken
  ) {
    return Ok();
  }

  /// <summary>
  /// Создание нового комментария
  /// </summary>
  /// <response code="200">Новый комментарий</response>
  /// <response code="400">Ошибка валидации</response>
  /// <response code="403">Недостаточно прав</response>
  [ProducesResponseType<ErrorContract>(StatusCodes.Status403Forbidden)]
  [ProducesResponseType<ErrorContract>(StatusCodes.Status400BadRequest)]
  [ProducesResponseType<CommentContract>(StatusCodes.Status200OK)]
  [HttpPost]
  [Authorize]
  public async Task<IActionResult> CreateCommentAsync(
    [FromBody] CreateCommentContract createCommentContract,
    [FromServices] CheckAccess.UseCase checkAccessUseCase,
    [FromServices] CreateComment.UseCase createCommentUseCase,
    CancellationToken cancellationToken
  ) {
    var checkAccessResult = await checkAccessUseCase
      .SetEntryData(new(
        GetClaimId(),
        createCommentContract.CourseId,
        PermissionType.Read))
      .ExecuteAsync(cancellationToken);

    if (checkAccessResult is CheckAccess.Results.NoAccess)
      return Forbidden(ErrorContract.Forbidden());

    var createCommentResult = await createCommentUseCase
      .SetEntryData(new(
        createCommentContract.CourseId,
        GetClaimId(),
        createCommentContract.Content,
        createCommentContract.Quality))
      .ExecuteAsync(cancellationToken);
    
    return createCommentResult switch {
      CreateComment.Results.Created { Comment: var comment } => Ok(comment),
      CreateComment.Results.CourseNotFound => NotFound(ErrorContract.NotFound($"Курс с идентификатором {createCommentContract.CourseId} не найден")),
      Results.ValidationFailure { ValidationResult: var validationResult } => BadRequest(ErrorContract.ValidationError(validationResult)),
      _ => CantHandleRequest()
    };
  }

  /// <summary>
  /// Удаление комментария по идентификатору
  /// </summary>
  [HttpDelete("{commentId:long:min(0)}")]
  public async Task<IActionResult> DeleteCommentByIdAsync(
    [FromRoute(Name = "commentId")] long commentId,
    CancellationToken cancellationToken
  ) {
    return Ok();
  }
}
