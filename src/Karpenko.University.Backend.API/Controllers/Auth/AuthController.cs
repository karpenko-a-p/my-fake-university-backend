using System.Net.Mime;
using Karpenko.University.Backend.API.Controllers.Auth.Contracts;
using GenerateJwtToken = Karpenko.University.Backend.Application.UseCases.GenerateJwtToken;
using CreateStudent = Karpenko.University.Backend.Application.UseCases.CreateStudent;
using Microsoft.AspNetCore.Mvc;

namespace Karpenko.University.Backend.API.Controllers.Auth;

/// <summary>
/// Контроллер для работы авторизацией
/// </summary>
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[Tags("api/auth/v1")]
[Route("api/auth/v1")]
public sealed class AuthController : ExtendedControllerBase {
  /// <summary>
  /// Регистрация студента
  /// </summary>
  [HttpPost("register")]
  public async Task<IActionResult> RegisterAsync(
    [FromBody] RegisterUserContract registerUserContract,
    [FromServices] GenerateJwtToken.UseCase generateJwtTokenUseCase,
    [FromServices] CreateStudent.UseCase createStudentUseCase,
    GenerateJwtToken.AuthOptions authOptions,
    CancellationToken cancellationToken
  ) {
    var studentCreatingResult = await createStudentUseCase
      .SetEntryData(registerUserContract.ToCreateStudentEntryData())
      .ExecuteAsync(cancellationToken);

    switch (studentCreatingResult) {
      case CreateStudent.Results.StudentAlreadyExists:
        return BadRequest(ErrorContract.AlreadyExists("Студент с такой почтой уже существует"));
      case CreateStudent.Results.ValidationError { ValidationResult: var errors }:
        return BadRequest(ErrorContract.ValidationError(errors));
      case CreateStudent.Results.EmptyData:
        return BadRequest(ErrorContract.IncorrectDataType());
    }
    
    if (studentCreatingResult is not CreateStudent.Results.StudentCreated { StudentModel: var studentModel })
      return CantHandleRequest();
    

    var jwtTokenGenerationResult = generateJwtTokenUseCase
      .SetEntryData(new(studentModel.Id, studentModel.Email))
      .Execute();

    if (jwtTokenGenerationResult is GenerateJwtToken.Results.TokenGenerated { Token: var token }) {
      Response.Cookies.Append(authOptions.CookieName, $"Bearer {token}", new CookieOptions {
        HttpOnly = true,
      });
    }
    
    return jwtTokenGenerationResult switch {
      GenerateJwtToken.Results.ValidationError { ValidationResult: var errors } => BadRequest(ErrorContract.ValidationError(errors)),
      GenerateJwtToken.Results.EmptyData => BadRequest(ErrorContract.IncorrectDataType()),
      _ => CantHandleRequest()
    };
  }

  [HttpPost("login")]
  public async Task<IActionResult> LoginAsync(
    [FromBody] LoginUserContract loginUserContract,
    CancellationToken cancellationToken
  ) {
    return Ok();
  }
}
