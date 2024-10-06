using Karpenko.University.Backend.Domain.Permission;

namespace Karpenko.University.Backend.Application.UseCases.CheckAccess;

/// <summary>
/// Данные для проверки доступов
/// </summary>
/// <param name="OwnerId">Владелец</param>
/// <param name="SubjectId">Субъект</param>
/// <param name="PermissionType">Тип права доступа</param>
public sealed record EntryData(
  long OwnerId,
  long SubjectId,
  PermissionType PermissionType);
