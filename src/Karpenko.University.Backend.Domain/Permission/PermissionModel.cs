namespace Karpenko.University.Backend.Domain.Permission;

/// <summary>
/// Модель права доступа
/// </summary>
public sealed class PermissionModel {
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
}
