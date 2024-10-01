using Karpenko.University.Backend.Application.Validation;
using Karpenko.University.Backend.Core.ResultPattern;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace Karpenko.University.Backend.Application.UseCases.GenerateJwtToken;

/// <summary>
/// Сценарий для регистрации пользователя
/// </summary>
public sealed class UseCase(
  IValidator<EntryData> entryDataValidator,
  IJwtService jwtService,
  IOptions<AuthOptions> authOptions
) : AbstractUseCase<EntryData> {
  /// <inheritdoc />
  public override IResult Execute() {
    var validationResult = entryDataValidator.Validate(EntryData);

    if (validationResult.IsFailure)
      return new Results.ValidationError(validationResult);

    Claim[] claims = [
      new(nameof(EntryData.Email), EntryData.Email!),
      new(nameof(EntryData.Id), EntryData.Id.GetValueOrDefault().ToString()),
    ];

    var generateJwtTokenDto = new GenerateJwtTokenDto(
      Issuer: authOptions.Value.Issuer,
      Audience: authOptions.Value.Audience,
      Secret: authOptions.Value.Secret,
      Claims: claims,
      Expires: TimeSpan.FromDays(30));

    var jwtToken = jwtService.GenerateJwtToken(generateJwtTokenDto);

    return new Results.TokenGenerated(jwtToken);
  }
}
