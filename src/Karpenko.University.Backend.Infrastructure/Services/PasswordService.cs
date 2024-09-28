using Karpenko.University.Backend.Application.UseCases.CreateStudent;
using BC = BCrypt.Net.BCrypt;

namespace Karpenko.University.Backend.Infrastructure.Services;

/// <summary>
/// Сервис для работы с паролями
/// </summary>
public sealed class PasswordService : IPasswordService {
  /// <inheritdoc />
  public string HashPassword(string password) {
    return BC.HashPassword(password);
  }

  /// <inheritdoc />
  public bool VerifyPasswords(string password, string hashedPassword) {
    return BC.Verify(hashedPassword, password);
  }
}
