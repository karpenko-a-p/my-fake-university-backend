namespace Karpenko.University.Backend.Application.UseCases.CreateStudent;

/// <summary>
/// Интерфейс сервиса для работы с паролями
/// </summary>
public interface IPasswordService {
  /// <summary>
  /// Хэширование пароля
  /// </summary>
  string HashPassword(string password);
}
