namespace Karpenko.University.Backend.Application.UseCases.AddAccess;

/// <summary>
/// Массив данных для предоставления прав доступа
/// </summary>
/// <param name="Permissions">Коллекция данных для создания прав</param>
public sealed record EntryData(ICollection<CreatePermissionDto> Permissions);
