using Karpenko.University.Backend.Application.Repositories;
using Karpenko.University.Backend.Domain.Student;

namespace Karpenko.University.Backend.Application.UseCases.CreateStudent;

/// <summary>
/// Репозиторий для работы с данными студентов
/// </summary>
public interface IStudentRepository : IRepository {
  /// <summary>
  /// Проверить существование студента по почте
  /// </summary>
  Task<bool> CheckStudentExistsByEmailAsync(string email, CancellationToken cancellationToken);

  /// <summary>
  /// Создание нового аккаунта студента
  /// </summary>
  Task<StudentModel> CreateStudentAsync(CreateStudentDto student, CancellationToken cancellationToken);
  
  /// <summary>
  /// Сохранение хэшированного пароля студента в таблицу с паролями
  /// </summary>
  Task SaveStudentPasswordAsync(ulong studentId, string password, CancellationToken cancellationToken);
}
