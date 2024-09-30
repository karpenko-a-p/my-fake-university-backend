using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.Login;

/// <summary>
/// Сценарий для авторизации пользователя
/// </summary>
public sealed class UseCase : AbstractAsyncUseCase<EntryData> {
  public override Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    throw new NotImplementedException();
  }
}
