using System.Net.Mime;
using Karpenko.University.Backend.API.Controllers.Auth.Contracts;
using Microsoft.AspNetCore.Authorization;
using GenerateJwtToken = Karpenko.University.Backend.Application.UseCases.GenerateJwtToken;
using CreateStudent = Karpenko.University.Backend.Application.UseCases.CreateStudent;
using VerifyStudentPassword = Karpenko.University.Backend.Application.UseCases.VerifyStudentPassword;
using GetStudentByEmail = Karpenko.University.Backend.Application.UseCases.GetStudentByEmail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Karpenko.University.Backend.API.Controllers.Auth;

/// <summary>
/// Контроллер для работы авторизацией
/// </summary>
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[Tags("api/auth/v1")]
[Route("api/auth/v1")]
public sealed class AuthController(IOptions<GenerateJwtToken.AuthOptions> authOptions) : ExtendedControllerBase {
  /// <summary>
  /// Сообщение об ошибке при верификации данных пользователя
  /// </summary>
  private const string InvalidLoginOrPassword = "Неверный логин или пароль";

  /// <summary>
  /// Регистрация студента
  /// </summary>
  /// <response code="200">Пользователь успешно зарегистрирован</response>
  /// <response code="400">Ошибка при регистрации пользователя</response>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType<ErrorContract>(StatusCodes.Status400BadRequest)]
  [HttpPost("register")]
  public async Task<IActionResult> RegisterAsync(
    [FromBody] RegisterUserContract registerUserContract,
    [FromServices] GenerateJwtToken.UseCase generateJwtTokenUseCase,
    [FromServices] CreateStudent.UseCase createStudentUseCase,
    CancellationToken cancellationToken
  ) {
    // Создание аккаунта студента
    var studentCreatingResult = await createStudentUseCase
      .SetEntryData(registerUserContract.ToCreateStudentEntryData())
      .ExecuteAsync(cancellationToken);

    switch (studentCreatingResult) {
      case CreateStudent.Results.StudentAlreadyExists:
        return BadRequest(ErrorContract.AlreadyExists("Студент с такой почтой уже существует"));
      case CreateStudent.Results.ValidationError { ValidationResult: var errors }:
        return BadRequest(ErrorContract.ValidationError(errors));
    }
    
    if (studentCreatingResult is not CreateStudent.Results.StudentCreated { StudentModel: var studentModel })
      return CantHandleRequest();

    // Генерация jwt токена
    var jwtTokenGenerationResult = generateJwtTokenUseCase
      .SetEntryData(new(studentModel.Id, studentModel.Email))
      .Execute();

    if (jwtTokenGenerationResult is GenerateJwtToken.Results.TokenGenerated { Token: var token }) {
      SetJwtTokenInCookie(token);
      return Ok();
    }

    return jwtTokenGenerationResult switch {
      GenerateJwtToken.Results.ValidationError { ValidationResult: var errors } => BadRequest(ErrorContract.ValidationError(errors)),
      _ => CantHandleRequest()
    };
  }

  /// <summary>
  /// Авторизация студента
  /// </summary>
  /// <response code="200">Успешная авторизация</response>
  /// <response code="400">Неверный логин или пароль</response>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType<ErrorContract>(StatusCodes.Status400BadRequest)]
  [HttpPost("login")]
  public async Task<IActionResult> LoginAsync(
    [FromBody] LoginUserContract loginUserContract,
    [FromServices] GenerateJwtToken.UseCase generateJwtTokenUseCase,
    [FromServices] VerifyStudentPassword.UseCase verifyStudentPasswordUseCase,
    [FromServices] GetStudentByEmail.UseCase getStudentByEmailUseCase,
    CancellationToken cancellationToken
  ) {
    // Поиск студента (проверка, что существует)
    var studentSearchResult = await getStudentByEmailUseCase
      .SetEntryData(new (loginUserContract.Email))
      .ExecuteAsync(cancellationToken);

    if (studentSearchResult is not GetStudentByEmail.Results.Found { Student: var student })
      return BadRequest(ErrorContract.BadRequest(errorMessage: InvalidLoginOrPassword));

    // Сверка паролей
    var verifyingResult = await verifyStudentPasswordUseCase
      .SetEntryData(new(student.Id, loginUserContract.Password))
      .ExecuteAsync(cancellationToken);

    if (verifyingResult is not VerifyStudentPassword.Results.PasswordVerified)
      return verifyingResult switch {
        VerifyStudentPassword.Results.ValidationError { ValidationResult: var errors } => BadRequest(ErrorContract.ValidationError(errors)),
        _ => BadRequest(ErrorContract.BadRequest(errorMessage: InvalidLoginOrPassword))
      };

    // Генерация jwt токена
    var jwtTokenGenerationResult = generateJwtTokenUseCase
      .SetEntryData(new(student.Id, student.Email))
      .Execute();

    if (jwtTokenGenerationResult is GenerateJwtToken.Results.TokenGenerated { Token: var token }) {
      SetJwtTokenInCookie(token);
      return Ok();
    }

    return jwtTokenGenerationResult switch {
      GenerateJwtToken.Results.ValidationError { ValidationResult: var errors } => BadRequest(ErrorContract.ValidationError(errors)),
      _ => CantHandleRequest()
    };
  }

  /// <summary>
  /// Выход из аккаунта
  /// </summary>
  /// <response code="200">Успешный выход</response>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [HttpPost("logout")]
  [Authorize]
  public IActionResult Logout() {
    Response.Cookies.Delete(authOptions.Value.CookieName);
    return Ok();
  }

  /// <summary>
  /// Установка jwt токена в куках
  /// </summary>
  private void SetJwtTokenInCookie(string token) {
    Response.Cookies.Append(authOptions.Value.CookieName, token, new CookieOptions {
      HttpOnly = true,
      Secure = true,
      SameSite = SameSiteMode.Strict,
      MaxAge = TimeSpan.FromDays(30)
    });
  }
}
