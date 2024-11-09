using Karpenko.University.Backend.Domain.Permission;

namespace Karpenko.University.Backend.Application.UseCases.AddAccess;

/// <summary>
/// Репозиторий для работы с данными по правам доступа
/// </summary>
public interface IPermissionRepository {
  /// <summary>
  /// Добавить запись с новыми правами
  /// </summary>
  Task<ICollection<PermissionModel>> AddPermissionAsync(
    ICollection<CreatePermissionInDBDto> permissions,
    CancellationToken cancellationToken);
}
