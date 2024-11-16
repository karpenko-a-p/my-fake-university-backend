using System.Net.Mime;
using Karpenko.University.Backend.Domain.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CheckAccess = Karpenko.University.Backend.Application.UseCases.CheckAccess;
using GetCourseVideo = Karpenko.University.Backend.Application.UseCases.GetCourseVideo;

namespace Karpenko.University.Backend.API.Controllers.CourseContent;

/// <summary>
/// Контроллер для работы с контентом курсов
/// </summary>
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[Tags("api/course-content/v1")]
[Route("api/course-content/v1")]
public sealed class CourseContentController : ExtendedControllerBase {
  /// <summary>
  /// Получение контента курса
  /// </summary>
  /// <response code="200">Контент курса</response>
  /// <response code="206">Фрагмент контента курса</response>
  /// <response code="403">Недостаточно прав</response>
  /// <response code="401">Необходима авторизация</response>
  [ProducesResponseType<ErrorContract>(StatusCodes.Status401Unauthorized)]
  [ProducesResponseType<ErrorContract>(StatusCodes.Status403Forbidden)]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status206PartialContent)]
  [Authorize]
  [HttpGet("{courseId:long:min(0)}/video")]
  public async Task<IActionResult> GetCourseContentAsync(
    [FromRoute(Name = "courseId")] long courseId,
    [FromServices] CheckAccess.UseCase checkAccessUseCase,
    [FromServices] GetCourseVideo.UseCase getCourseVideoUseCase,
    CancellationToken cancellationToken
  ) {
    var checkAccessResult = await checkAccessUseCase
      .SetEntryData(new(GetClaimId(), courseId, PermissionType.Read, PermissionSubject.CourseContent))
      .ExecuteAsync(cancellationToken);

    if (checkAccessResult is not CheckAccess.Results.HasAccess)
      return Forbidden(ErrorContract.Forbidden("Нет доступа к курсу"));

    var (start, end) = GetRangeParams(Request.Headers.Range.ToString());

    var getVideoResult = await getCourseVideoUseCase
      .SetEntryData(new(courseId, start, end))
      .ExecuteAsync(cancellationToken);

    if (getVideoResult is GetCourseVideo.Results.FilePart filePart) {
      Response.StatusCode = 206;
      Response.Headers.Append("Content-Range", $"bytes {filePart.PartStart}-{filePart.PartEnd}/{filePart.FileSize}");
      Response.Headers.Append("Accept-Ranges", "bytes");
      Response.Headers.Append("Content-Length", filePart.PartLength.ToString());

      return File(filePart.Stream, $"video/{filePart.FileExt}", true);
    }

    return getVideoResult switch {
      GetCourseVideo.Results.File file => File(file.Stream, $"video/{file.FileExt}", true),
      Application.Validation.Results.ValidationFailure { ValidationResult: var validationResult } => BadRequest(ErrorContract.ValidationError(validationResult)),
      GetCourseVideo.Results.CourseNotFound => NotFound(ErrorContract.NotFound("Курс не найден")),
      GetCourseVideo.Results.VideoNotFound => NotFound(ErrorContract.NotFound("Содержимое курса не найдено")),
      _ => CantHandleRequest()
    };
  }

  /// <summary>
  /// Получение параметров хэдера Range
  /// </summary>
  private static (long start, long end) GetRangeParams(string range) {
    var rangeParts = range.Replace("bytes=", "").Split('-');

    long start = default;
    long end = default;
    
    if (rangeParts.Length >= 1)
      long.TryParse(rangeParts[0], out start);
    
    if (rangeParts.Length >= 2)
      long.TryParse(rangeParts[1], out end);
    
    return (start, end);
  }
}
