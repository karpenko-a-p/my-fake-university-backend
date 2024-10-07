using Karpenko.University.Backend.Domain.Permission;

namespace Karpenko.University.Backend.Application.UseCases.AddAccess;

/// <summary>
/// Данные для предоставления прав доступа
/// </summary>
/// <param name="OwnerId">Кому предоставляются права</param>
/// <param name="SubjectId">Права на что</param>
/// <param name="PermissionType">Тип прав</param>
public sealed record EntryData(
  long OwnerId,
  long SubjectId,
  PermissionType PermissionType);
