﻿using System.Net.Mime;
using Karpenko.University.Backend.API.Controllers.Comment.Contracts;
using Karpenko.University.Backend.Application.Pagination;
using Karpenko.University.Backend.Domain.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CheckAccess = Karpenko.University.Backend.Application.UseCases.CheckAccess;
using CreateComment = Karpenko.University.Backend.Application.UseCases.CreateComment;
using AddAccess = Karpenko.University.Backend.Application.UseCases.AddAccess;
using DeleteCommentById = Karpenko.University.Backend.Application.UseCases.DeleteCommentById;
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
    [FromServices] AddAccess.UseCase addAccessUseCase,
    CancellationToken cancellationToken
  ) {
    var studentId = GetClaimId();

    // Проверка прав, что есть доступ курсу для которого пишется коммент
    var checkAccessResult = await checkAccessUseCase
      .SetEntryData(new(studentId, createCommentContract.CourseId, PermissionType.Read))
      .ExecuteAsync(cancellationToken);

    if (checkAccessResult is CheckAccess.Results.NoAccess)
      return Forbidden(ErrorContract.Forbidden());

    // Создание комментария
    var createCommentResult = await createCommentUseCase
      .SetEntryData(new(
        createCommentContract.CourseId,
        studentId,
        createCommentContract.Content,
        createCommentContract.Quality))
      .ExecuteAsync(cancellationToken);

    if (createCommentResult is not CreateComment.Results.Created { Comment: var comment })
      return createCommentResult switch {
        CreateComment.Results.CourseNotFound => NotFound(ErrorContract.NotFound($"Курс с идентификатором {createCommentContract.CourseId} не найден")),
        Results.ValidationFailure { ValidationResult: var validationResult } => BadRequest(ErrorContract.ValidationError(validationResult)),
        _ => CantHandleRequest()
      };
    
    // Предоставление доступа
    var addAccessResult = await addAccessUseCase
      .SetEntryData(new(studentId, comment.Id, PermissionType.Delete))
      .ExecuteAsync(cancellationToken);
    
    if (addAccessResult is not AddAccess.Results.Success)
      return BadRequest(ErrorContract.BadRequest());
    
    return Ok(new CommentContract(comment));
  }

  /// <summary>
  /// Удаление комментария по идентификатору
  /// </summary>
  /// <response code="200">Комментарий удален</response>
  /// <response code="403">Недостаточно прав</response>
  /// <response code="404">Комментарий не найден</response>
  [ProducesResponseType<ErrorContract>(StatusCodes.Status404NotFound)]
  [ProducesResponseType<ErrorContract>(StatusCodes.Status403Forbidden)]
  [ProducesResponseType<CommentContract>(StatusCodes.Status200OK)]
  [Authorize]
  [HttpDelete("{commentId:long:min(0)}")]
  public async Task<IActionResult> DeleteCommentByIdAsync(
    [FromRoute(Name = "commentId")] long commentId,
    [FromServices] CheckAccess.UseCase checkAccessUseCase,
    [FromServices] DeleteCommentById.UseCase deleteCommentByIdUseCase,
    CancellationToken cancellationToken
  ) {
    var studentId = GetClaimId();

    // Проверка доступа
    var checkAccessResult = await checkAccessUseCase
      .SetEntryData(new(studentId, commentId, PermissionType.Delete))
      .ExecuteAsync(cancellationToken);

    if (checkAccessResult is not CheckAccess.Results.HasAccess)
      return Forbidden(ErrorContract.Forbidden());
    
    // Удаление комментария
    var deleteResult = await deleteCommentByIdUseCase
      .SetEntryData(studentId.GetValueOrDefault())
      .ExecuteAsync(cancellationToken);

    return deleteResult switch {
      DeleteCommentById.Results.Deleted { Comment: var comment } => Ok(new CommentContract(comment)),
      DeleteCommentById.Results.NotFound => NotFound(ErrorContract.NotFound($"Не найден комментарий с идентификатором {commentId}")),
      _ => CantHandleRequest()
    };
  }
}
