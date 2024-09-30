namespace Karpenko.University.Backend.Application.UseCases.GenerateJwtToken;

/// <summary>
/// Сервис для работы с jwt токенами
/// </summary>
public interface IJwtService {
  /// <summary>
  /// Генерация jwt токена
  /// </summary>
  string GenerateJwtToken(GenerateJwtTokenDto generateJwtTokenDto);
}
