namespace Karpenko.University.Backend.Application.UseCases.DeleteStudentById;

/// <summary>
/// Интерфейс для работы с данными студентами 
/// </summary>
public interface IStudentRepository {
  /// <summary>
  /// Удаление студента по идентификатору
  /// </summary>
  Task<bool> DeleteStudentByIdAsync(ulong id, CancellationToken cancellationToken);
}
