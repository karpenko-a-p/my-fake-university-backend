using Karpenko.University.Backend.Domain.Permission;

namespace Karpenko.University.Backend.Persistence.Database.Entities;

/// <summary>
/// Сущность права доступа
/// </summary>
internal sealed class PermissionEntity {
  /// <summary>
  /// Идентификатор кому принадлежит право доступа
  /// </summary>
  public long OwnerId { get; set; }
  
  /// <summary>
  /// Идентификатор над кем/чем может производиться действие 
  /// </summary>
  public long SubjectId { get; set; }
  
  /// <summary>
  /// Тип доступа
  /// </summary>
  public PermissionType PermissionType { get; set; }

  /// <summary>
  /// Приведение сущности из БД к модели права доступа
  /// </summary>
  public PermissionModel ToPermissionModel() {
    return new() {
      OwnerId = OwnerId,
      SubjectId = SubjectId,
      PermissionType = PermissionType
    };
  }
}
