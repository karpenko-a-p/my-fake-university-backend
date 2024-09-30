using System.Text;
using Karpenko.University.Backend.Application.UseCases.GenerateJwtToken;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Karpenko.University.Backend.Infrastructure.Services;

/// <summary>
/// Сервис для работы с jwt токенами
/// </summary>
internal sealed class JwtService : IJwtService {
  /// <inheritdoc />
  public string GenerateJwtToken(GenerateJwtTokenDto generateJwtTokenDto) {
    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(generateJwtTokenDto.Secret));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var jwtSecurityToken = new JwtSecurityToken(
      claims: generateJwtTokenDto.Claims,
      signingCredentials: credentials,
      issuer: generateJwtTokenDto.Issuer,
      audience: generateJwtTokenDto.Audience,
      expires: DateTime.UtcNow.Add(generateJwtTokenDto.Expires));

    return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
  }
}
