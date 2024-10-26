using System.Net.Mime;
using Karpenko.University.Backend.Application.Pagination;
using Microsoft.AspNetCore.Mvc;

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
  [HttpPost]
  public async Task<IActionResult> CreateCommentAsync(
    CancellationToken cancellationToken
  ) {
    return Ok();
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
