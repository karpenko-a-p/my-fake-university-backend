using Karpenko.University.Backend.Domain.Permission;

namespace Karpenko.University.Backend.Application.UseCases.AddAccess;

/// <summary>
/// Репозиторий для работы с данными по правам доступа
/// </summary>
public interface IPermissionRepository {
  /// <summary>
  /// Добавить запись с новыми правами
  /// </summary>
  Task<PermissionModel> AddPermissionAsync(
    long ownerId,
    long subjectId,
    PermissionType permissionType,
    CancellationToken cancellationToken);
}
