using System.Net.Mime;
using Karpenko.University.Backend.API.Controllers.Tag.Contracts;
using GetCoursesTags = Karpenko.University.Backend.Application.UseCases.GetCoursesTags;
using Microsoft.AspNetCore.Mvc;

namespace Karpenko.University.Backend.API.Controllers.Tag;

/// <summary>
/// Контроллер для работы с тэгами курсов
/// </summary>
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[Tags("api/tags/v1")]
[Route("api/tags/v1")]
public sealed class TagController : ExtendedControllerBase {
  /// <summary>
  /// Получение списка всех тэгов курсов
  /// </summary>
  /// <responses code="200">Список тэгов</responses>
  [ProducesResponseType<TagContract[]>(StatusCodes.Status200OK)]
  [HttpGet]
  public async Task<IActionResult> GetTagsAsync(
    [FromServices] GetCoursesTags.UseCase getCoursesTagsUseCase,
    CancellationToken cancellationToken
  ) {
    var getTagsResult = await getCoursesTagsUseCase.ExecuteAsync(cancellationToken);

    if (getTagsResult is not GetCoursesTags.Results.TagsCollection { Tags: var tags })
      return CantHandleRequest();

    var mappedTags = tags.Select(tag => new TagContract(tag)).ToArray();
    
    return Ok(mappedTags);
  }
}
