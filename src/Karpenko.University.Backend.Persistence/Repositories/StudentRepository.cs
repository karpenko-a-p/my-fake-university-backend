using Karpenko.University.Backend.Application.UseCases.CreateStudent;
using Karpenko.University.Backend.Domain.Student;

namespace Karpenko.University.Backend.Persistence.Repositories;

/// <summary>
/// Репозиторий для работы с данными студентов
/// </summary>
public sealed class StudentRepository : IStudentRepository {
  /// <inheritdoc />
  public Task<bool> CheckStudentExistsByEmailAsync(string email, CancellationToken cancellationToken) {
    // TODO заглушка
    return Task.FromResult(email == "asd@asd.asd");
  }

  /// <inheritdoc />
  public Task<StudentModel> CreateStudentAsync(CreateStudentDto createStudentDto, CancellationToken cancellationToken) {
    // TODO заглушка
    return Task.FromResult(new StudentModel {
      Email = createStudentDto.Email,
      Id = 100,
      Name = createStudentDto.Name,
      AvatarUrl = "",
      RegistrationDate = DateTime.Now
    });
  }
}
