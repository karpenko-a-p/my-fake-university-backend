using CheckAccess = Karpenko.University.Backend.Application.UseCases.CheckAccess;
using Karpenko.University.Backend.Domain.Permission;
using Karpenko.University.Backend.Persistence.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Karpenko.University.Backend.Persistence.Repositories;

/// <summary>
/// Репозиторий для работы с правами пользователей
/// </summary>
internal sealed class PermissionRepository(PostgresDbContext db) : CheckAccess.IPermissionRepository {
  /// <inheritdoc />
  public Task<bool> CheckHasAccessAsync(
    long ownerId,
    long subjectId,
    PermissionType permissionType,
    CancellationToken cancellationToken
  ) {
    return db.Permissions.AnyAsync(permission => permission.OwnerId == ownerId &&
                                                 permission.SubjectId == subjectId &&
                                                 permission.PermissionType == permissionType, cancellationToken);
  }
}
