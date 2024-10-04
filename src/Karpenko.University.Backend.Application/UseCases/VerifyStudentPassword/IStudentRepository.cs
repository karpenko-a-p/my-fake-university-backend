namespace Karpenko.University.Backend.Application.UseCases.VerifyStudentPassword;

/// <summary>
/// Репозиторий для работы с данными студентов
/// </summary>
public interface IStudentRepository {
  /// <summary>
  /// Получение пароля пользователя по почте 
  /// </summary>
  Task<string?> GetStudentPasswordByIdAsync(ulong id, CancellationToken cancellationToken);
}
