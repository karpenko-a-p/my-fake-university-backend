using CreateStudent = Karpenko.University.Backend.Application.UseCases.CreateStudent;
using GetStudentByExpression = Karpenko.University.Backend.Application.UseCases.GetStudentByExpression;
using VerifyStudentPassword = Karpenko.University.Backend.Application.UseCases.VerifyStudentPassword;
using Karpenko.University.Backend.Domain.Student;

namespace Karpenko.University.Backend.Persistence.Repositories;

/// <summary>
/// Репозиторий для работы с данными студентов
/// </summary>
internal sealed class StudentRepository :
  CreateStudent.IStudentRepository,
  GetStudentByExpression.IStudentRepository,
  VerifyStudentPassword.IStudentRepository
{
  /// <inheritdoc />
  public Task<bool> CheckStudentExistsByEmailAsync(string email, CancellationToken cancellationToken) {
    // TODO заглушка
    return Task.FromResult(email == "asd@asd.asd");
  }

  /// <inheritdoc />
  public Task<StudentModel> CreateStudentAsync(CreateStudent.CreateStudentDto createStudentDto, CancellationToken cancellationToken) {
    // TODO заглушка
    return Task.FromResult(new StudentModel {
      Email = createStudentDto.Email,
      Id = 100,
      Name = createStudentDto.Name,
      AvatarUrl = "",
      RegistrationDate = DateTime.UtcNow
    });
  }

  /// <inheritdoc />
  public async Task<StudentModel?> GetStudentByExpressionAsync(Func<GetStudentByExpression.IStudentSearchable, bool> expression, CancellationToken cancellationToken) {
    // TODO заглушка
    var candidate = Enumerable.Empty<GetStudentByExpression.IStudentSearchable>().FirstOrDefault(expression);

    if (candidate is null) return null;

    return new();
  }

  /// <inheritdoc />
  public async Task<string?> GetStudentPasswordByIdAsync(ulong id, CancellationToken cancellationToken) {
    return "123456";
  }
}
