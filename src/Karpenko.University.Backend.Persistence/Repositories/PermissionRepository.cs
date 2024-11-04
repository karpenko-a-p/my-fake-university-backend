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
  public async Task<PermissionModel> AddPermissionAsync(
    long ownerId,
    long subjectId,
    PermissionType permissionType,
    PermissionSubject permissionSubject,
    CancellationToken cancellationToken
  ) {
    var permission = new PermissionEntity {
      OwnerId = ownerId,
      SubjectId = subjectId,
      PermissionType = permissionType,
      PermissionSubject = permissionSubject
    };
    
    await db.Permissions.AddAsync(permission, cancellationToken);
    await db.SaveChangesAsync(cancellationToken);

    return permission.ToPermissionModel();
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
