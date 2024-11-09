using CheckAccess = Karpenko.University.Backend.Application.UseCases.CheckAccess;
using AddAccess = Karpenko.University.Backend.Application.UseCases.AddAccess;
using CreateStudent = Karpenko.University.Backend.Application.UseCases.CreateStudent;
using Karpenko.University.Backend.Domain.Permission;
using Karpenko.University.Backend.Persistence.Database.Contexts;
using Karpenko.University.Backend.Persistence.Database.Entities.Permission;
using Microsoft.EntityFrameworkCore;

namespace Karpenko.University.Backend.Persistence.Repositories;

/// <summary>
/// Репозиторий для работы с правами пользователей
/// </summary>
internal sealed class PermissionRepository(PostgresDbContext db) :
  CheckAccess.IPermissionRepository,
  AddAccess.IPermissionRepository,
  CreateStudent.IPermissionRepository
{
  /// <inheritdoc />
  public Task<bool> CheckHasAccessAsync(
    long ownerId,
    long subjectId,
    PermissionType permissionType,
    PermissionSubject permissionSubject,
    CancellationToken cancellationToken
  ) {
    return db.Permissions.AnyAsync(permission => permission.OwnerId == ownerId &&
                                                 permission.SubjectId == subjectId &&
                                                 permission.PermissionSubject == permissionSubject &&
                                                 permission.PermissionType == permissionType, cancellationToken);
  }

  /// <inheritdoc />
  public async Task<ICollection<PermissionModel>> AddPermissionAsync(
    ICollection<AddAccess.CreatePermissionInDBDto> permissions,
    CancellationToken cancellationToken
  ) {
    var newPermissions =permissions.Select(permission => new PermissionEntity {
      OwnerId = permission.OwnerId,
      SubjectId = permission.SubjectId,
      PermissionType = permission.PermissionType,
      PermissionSubject = permission.PermissionSubject,
    });
    
    await db.Permissions.AddRangeAsync(newPermissions, cancellationToken);
    await db.SaveChangesAsync(cancellationToken);

    return newPermissions.Select(permission => new PermissionModel {
      OwnerId = permission.OwnerId,
      PermissionSubject = permission.PermissionSubject,
      PermissionType = permission.PermissionType,
      SubjectId = permission.SubjectId
    }).ToList();
  }

  /// <inheritdoc />
  public async Task AddPermissionsToStudentAsync(IEnumerable<PermissionModel> permissions, CancellationToken cancellationToken) {
    var permissionEntities = permissions.Select(model => new PermissionEntity {
      OwnerId = model.OwnerId,
      SubjectId = model.SubjectId,
      PermissionType = model.PermissionType,
      PermissionSubject = model.PermissionSubject
    });

    await db.Permissions.AddRangeAsync(permissionEntities, cancellationToken);
    await db.SaveChangesAsync(cancellationToken);
  }
}
