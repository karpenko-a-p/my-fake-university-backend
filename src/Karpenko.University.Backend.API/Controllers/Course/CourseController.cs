using System.Net.Mime;
using Karpenko.University.Backend.API.Controllers.Course.Contracts;
using Karpenko.University.Backend.Application.Pagination;
using Microsoft.AspNetCore.Mvc;
using GetCourses = Karpenko.University.Backend.Application.UseCases.GetCourses;
using GetCourseById = Karpenko.University.Backend.Application.UseCases.GetCourseById;
using GetCoursesByTagId = Karpenko.University.Backend.Application.UseCases.GetCoursesByTagId;

namespace Karpenko.University.Backend.API.Controllers.Course;

/// <summary>
/// Контроллер для работы с курсами
/// </summary>
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[Tags("api/courses/v1")]
[Route("api/courses/v1")]
public sealed class CourseController : ExtendedControllerBase {
  /// <summary>
  /// Получение списка курсов
  /// </summary>
  /// <response code="200">Пагинированный список курсов</response>
  [ProducesResponseType<PaginatedItems<CourseContract>>(StatusCodes.Status200OK)]
  [HttpGet]
  public async Task<IActionResult> GetCoursesAsync(
    [FromQuery] PaginationModel pagination,
    CancellationToken cancellationToken,
    [FromServices] GetCourses.UseCase getCourseUseCase
  ) {
    var getCoursesResult = await getCourseUseCase
      .SetEntryData(pagination)
      .ExecuteAsync(cancellationToken);

    if (getCoursesResult is not GetCourses.Results.CoursesCollection { Courses: var courses })
      return CantHandleRequest();

    var mappedCourses = courses.Map(course => new CourseContract(course));

    return Ok(mappedCourses);
  }

  /// <summary>
  /// Получение курса по идентификатору
  /// </summary>
  /// <response code="404">Не найдено</response>
  [ProducesResponseType<CourseContract>(StatusCodes.Status200OK)]
  [ProducesResponseType<ErrorContract>(StatusCodes.Status404NotFound)]
  [HttpGet("{id:min(0):long}")]
  public async Task<IActionResult> GetCourseByIdAsync(
    CancellationToken cancellationToken,
    [FromRoute(Name = "id")] long id,
    [FromServices] GetCourseById.UseCase getCourseByIdUseCase
  ) {
    var gerCourseResult = await getCourseByIdUseCase
      .SetEntryData(id)
      .ExecuteAsync(cancellationToken);

    return gerCourseResult switch {
      GetCourseById.Results.Found { Course: var course } => Ok(new CourseContract(course)),
      GetCourseById.Results.NotFound => NotFound(ErrorContract.NotFound()),
      _ => CantHandleRequest()
    };
  }
  
  /// <summary>
  /// Получение списка курсов по тэгу
  /// </summary>
  /// <response code="200">Список курсов</response>
  [ProducesResponseType<PaginatedItems<CourseContract>>(StatusCodes.Status200OK)]
  [HttpGet("by-tag/{id:min(0):long}")]
  public async Task<IActionResult> GetCoursesByTagAsync(
    [FromQuery] PaginationModel pagination,
    [FromRoute(Name = "id")] long tagId,
    [FromServices] GetCoursesByTagId.UseCase getCourseByTagIdUseCase,
    CancellationToken cancellationToken
  ) {
    var coursesResult = await getCourseByTagIdUseCase
      .SetEntryData(new(tagId, pagination))
      .ExecuteAsync(cancellationToken);

    if (coursesResult is not GetCoursesByTagId.Results.CoursesCollection { Courses: var courses })
      return CantHandleRequest();
    
    var mappedCourses = courses.Map(course => new CourseContract(course));
    
    return Ok(mappedCourses);
  }
}
