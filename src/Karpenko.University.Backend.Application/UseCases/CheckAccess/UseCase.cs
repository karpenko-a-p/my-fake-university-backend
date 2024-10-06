using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.CheckAccess;

/// <summary>
/// Сценарий проверки доступов
/// </summary>
public sealed class UseCase(IPermissionRepository permissionRepository) : AbstractAsyncUseCase<EntryData> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var hasAccess = await permissionRepository.CheckHasAccessAsync(
      EntryData.OwnerId,
      EntryData.SubjectId,
      EntryData.PermissionType,
      cancellationToken);
    
    return hasAccess
      ? new Results.HasAccess()
      : new Results.NoAccess();
  }
}
