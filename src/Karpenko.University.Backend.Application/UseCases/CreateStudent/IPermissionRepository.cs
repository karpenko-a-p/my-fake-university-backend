using Karpenko.University.Backend.Domain.Permission;

namespace Karpenko.University.Backend.Application.UseCases.CreateStudent;

/// <summary>
/// Репозиторий для работы с правами
/// </summary>
public interface IPermissionRepository {
  /// <summary>
  /// Добавление базовых прав студенту
  /// </summary>
  Task AddPermissionsToStudentAsync(IEnumerable<PermissionModel> permissions, CancellationToken cancellationToken);
}
