using System.Net.Mime;
using Karpenko.University.Backend.API.Controllers.Student.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CreateStudent = Karpenko.University.Backend.Application.UseCases.CreateStudent;
using GetStudentById = Karpenko.University.Backend.Application.UseCases.GetStudentById;

namespace Karpenko.University.Backend.API.Controllers.Student;

/// <summary>
/// Контроллер для работы со студентами
/// </summary>
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[Tags("api/students/v1")]
[Route("api/students/v1")]
public sealed class StudentController : ExtendedControllerBase {
  /// <summary>
  /// Создание нового студента
  /// </summary>
  /// <response code="200">Студен создан</response>
  /// <response code="400">Некорректные данные</response>
  [ProducesResponseType<ErrorContract>(StatusCodes.Status400BadRequest)]
  [ProducesResponseType<StudentContract>(StatusCodes.Status200OK)]
  [Authorize]
  [HttpPost("create-student")]
  public async Task<IActionResult> CreateStudentAsync(
    [FromServices] CreateStudent.UseCase createStudentUseCase,
    [FromBody] CreateStudentContract createStudentContract,
    CancellationToken cancellationToken
  ) {
    var studentCreatingResult = await createStudentUseCase
      .SetEntryData(createStudentContract.ToCreateStudentEntryData())
      .ExecuteAsync(cancellationToken);

    return studentCreatingResult switch {
      CreateStudent.Results.StudentCreated { StudentModel: var studentModel } => Ok(new StudentContract(studentModel)),
      CreateStudent.Results.StudentAlreadyExists => BadRequest(ErrorContract.AlreadyExists("Студент с такой почтой уже существует")),
      CreateStudent.Results.ValidationError { ValidationResult: var errors  } => BadRequest(ErrorContract.ValidationError(errors)),
      _ => CantHandleRequest()
    };
  }

  /// <summary>
  /// Получение студента по идентификатору
  /// </summary>
  /// <response code="200">Студен найден</response>
  /// <response code="404">Студен не найден</response>
  [ProducesResponseType<ErrorContract>(StatusCodes.Status404NotFound)]
  [ProducesResponseType<StudentContract>(StatusCodes.Status200OK)]
  [HttpGet("{id:long:min(0)}")]
  public async Task<IActionResult> GetStudentByIdAsync(
    [FromRoute(Name = "id")] ulong studentId,
    [FromServices] GetStudentById.UseCase getStudentByIdUseCase,
    CancellationToken cancellationToken
  ) {
    var studentSearchResult = await getStudentByIdUseCase
      .SetEntryData(new(studentId))
      .ExecuteAsync(cancellationToken);
    
    if (studentSearchResult is not GetStudentById.Results.Found { Student: var student })
      return NotFound(ErrorContract.NotFound(errorMessage: "Студент не найден"));

    return Ok(new StudentContract(student));
  }

  /// <summary>
  /// Удаление студента по идентификатору
  /// </summary>
  /// <response code="200">Студен удален</response>
  /// <response code="404">Студен не найден</response>
  [ProducesResponseType<ErrorContract>(StatusCodes.Status404NotFound)]
  [ProducesResponseType<StudentContract>(StatusCodes.Status200OK)]
  [HttpDelete("{id:long:min(0)}")]
  public async Task<IActionResult> DeleteStudentByIdAsync() {
    return Ok();
  }
}
