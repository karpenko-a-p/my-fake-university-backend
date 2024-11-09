using Karpenko.University.Backend.Domain.Permission;

namespace Karpenko.University.Backend.Application.UseCases.AddAccess;

/// <summary>
/// Данные для предоставления прав доступа для создания записа в БД
/// </summary>
/// <param name="OwnerId">Кому предоставляются права</param>
/// <param name="SubjectId">Права на что</param>
/// <param name="PermissionType">Тип прав</param>
public record CreatePermissionInDBDto(
  long OwnerId,
  long SubjectId,
  PermissionType PermissionType,
  PermissionSubject PermissionSubject
) {
  /// <summary>
  /// Получение дто для транспортировки
  /// </summary>
  public CreatePermissionInDBDto(CreatePermissionDto createPermissionDto) : this(
    createPermissionDto.OwnerId.GetValueOrDefault(),
    createPermissionDto.SubjectId.GetValueOrDefault(),
    createPermissionDto.PermissionType,
    createPermissionDto.PermissionSubject) {}
};
