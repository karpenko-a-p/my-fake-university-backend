using System.Net.Mime;
using Karpenko.University.Backend.Application.Pagination;
using Microsoft.AspNetCore.Mvc;
using GetCourses = Karpenko.University.Backend.Application.UseCases.GetCourses;

namespace Karpenko.University.Backend.API.Controllers.Course;

/// <summary>
/// Контроллер для работы с курсами
/// </summary>
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[Tags("api/courses/v1")]
[Route("api/courses/v1")]
public sealed class CourseController([FromServices] ILogger<CourseController> logger) : ExtendedControllerBase {
  /// <summary>
  /// Получение списка курсов
  /// </summary>
  [HttpGet]
  public async Task<IActionResult> GetCoursesAsync(
    [FromQuery] PaginationModel pagination,
    CancellationToken cancellationToken,
    [FromServices] GetCourses.UseCase getCourseUseCase
  ) {
    var getCoursesResult = await getCourseUseCase
      .SetEntryData(pagination)
      .ExecuteAsync(cancellationToken);

    return getCoursesResult switch {
      GetCourses.Results.CoursesCollection { Courses: var courses } => Ok(courses),
      _ => CantHandleRequest()
    };
  }
}
