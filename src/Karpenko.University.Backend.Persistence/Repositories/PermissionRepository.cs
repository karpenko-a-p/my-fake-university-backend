using CheckAccess = Karpenko.University.Backend.Application.UseCases.CheckAccess;
using AddAccess = Karpenko.University.Backend.Application.UseCases.AddAccess;
using Karpenko.University.Backend.Domain.Permission;
using Karpenko.University.Backend.Persistence.Database.Contexts;
using Karpenko.University.Backend.Persistence.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Karpenko.University.Backend.Persistence.Repositories;

/// <summary>
/// Репозиторий для работы с правами пользователей
/// </summary>
internal sealed class PermissionRepository(PostgresDbContext db) :
  CheckAccess.IPermissionRepository,
  AddAccess.IPermissionRepository
{
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

  /// <inheritdoc />
  public async Task<PermissionModel> AddPermissionAsync(
    long ownerId,
    long subjectId,
    PermissionType permissionType,
    CancellationToken cancellationToken
  ) {
    var permission = new PermissionEntity {
      OwnerId = ownerId,
      SubjectId = subjectId,
      PermissionType = permissionType
    };
    
    await db.Permissions.AddAsync(permission, cancellationToken);
    await db.SaveChangesAsync(cancellationToken);

    return permission.ToPermissionModel();
  }
}
