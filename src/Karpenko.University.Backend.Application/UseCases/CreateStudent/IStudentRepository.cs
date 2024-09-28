using Karpenko.University.Backend.Domain.Student;

namespace Karpenko.University.Backend.Application.UseCases.CreateStudent;

/// <summary>
/// Репозиторий для работы с данными студентов
/// </summary>
public interface IStudentRepository {
  /// <summary>
  /// Проверить существование студента по почте
  /// </summary>
  Task<bool> CheckStudentExistsByEmailAsync(string email, CancellationToken cancellationToken);

  /// <summary>
  /// Создание нового аккаунта студента
  /// </summary>
  Task<StudentModel> CreateStudentAsync(CreateStudentDto student, CancellationToken cancellationToken);
}
