using Karpenko.University.Backend.Domain.Permission;

namespace Karpenko.University.Backend.Application.UseCases.CheckAccess;

/// <summary>
/// Репозиторий для работы с правами пользователей
/// </summary>
public interface IPermissionRepository {
  /// <summary>
  /// Проверка есть на наличие доступа
  /// </summary>
  Task<bool> CheckHasAccessAsync(long ownerId, long subjectId, PermissionType permissionType, CancellationToken cancellationToken);
}
