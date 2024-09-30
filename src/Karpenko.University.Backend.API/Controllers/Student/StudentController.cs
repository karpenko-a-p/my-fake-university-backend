using System.Net.Mime;
using Karpenko.University.Backend.API.Controllers.Student.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CreateStudent = Karpenko.University.Backend.Application.UseCases.CreateStudent;

namespace Karpenko.University.Backend.API.Controllers.Student;

/// <summary>
/// Контроллер для работы со студентами
/// </summary>
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[Tags("api/students/v1")]
[Route("api/students/v1")]
public sealed class StudentController(ILogger<StudentController> logger) : ExtendedControllerBase {
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
      CreateStudent.Results.EmptyData => BadRequest(ErrorContract.IncorrectDataType()),
      _ => CantHandleRequest()
    };
  }
}
