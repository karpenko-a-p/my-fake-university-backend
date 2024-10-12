using System.Net.Mime;
using System.Text;
using Karpenko.University.Backend.Application.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

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
  [HttpGet("cache-test")]
  public async Task<IActionResult> GetCoursesAsync(
    [FromQuery] PaginationModel pagination,
    CancellationToken cancellationToken,
    [FromServices] IDistributedCache cache
  ) {
    const string cacheKey = "date";
    var data = await cache.GetAsync("date", cancellationToken);

    if (data is null) {
      var currentDate = DateTime.Now.ToString();

      await cache.SetAsync(
        cacheKey,
        Encoding.UTF8.GetBytes(currentDate),
        new() { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10) },
        cancellationToken);

      return Ok(currentDate);
    }
    
    return Ok(Encoding.UTF8.GetString(data));
  }
}
