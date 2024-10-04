namespace Karpenko.University.Backend.Application.UseCases.VerifyStudentPassword;

/// <summary>
/// Сервис для работы с паролями
/// </summary>
public interface IPasswordService {
  /// <summary>
  /// Верификация пароля
  /// </summary>
  bool VerifyPasswords(string password, string hashedPassword);
}
