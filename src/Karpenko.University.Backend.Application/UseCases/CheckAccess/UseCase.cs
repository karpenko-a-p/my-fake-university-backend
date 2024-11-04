using Karpenko.University.Backend.Application.Validation;
using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.CheckAccess;

/// <summary>
/// Сценарий проверки доступов
/// </summary>
public sealed class UseCase(
  IPermissionRepository permissionRepository,
  IValidator<EntryData> entryDataValidator
) : AbstractAsyncUseCase<EntryData> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var validationResult = entryDataValidator.Validate(EntryData);

    if (validationResult.IsFailure)
      return new Validation.Results.ValidationFailure(validationResult);

    var hasAccess = await permissionRepository.CheckHasAccessAsync(
      EntryData.OwnerId.GetValueOrDefault(),
      EntryData.SubjectId.GetValueOrDefault(),
      EntryData.PermissionType,
      EntryData.PermissionSubject,
      cancellationToken);

    return hasAccess
      ? new Results.HasAccess()
      : new Results.NoAccess();
  }
}
