using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.AddAccess;

/// <summary>
/// Сценарий предоставления доступа
/// </summary>
public sealed class UseCase(IPermissionRepository permissionRepository) : AbstractAsyncUseCase<EntryData> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var permission = await permissionRepository.AddPermissionAsync(
      EntryData.OwnerId,
      EntryData.SubjectId,
      EntryData.PermissionType,
      cancellationToken);
    
    return new Results.Success(permission);
  }
}
