namespace Karpenko.University.Backend.Domain.Order;

/// <summary>
/// Статус оплаты заказа
/// </summary>
public enum PaymentStatus : byte {
  /// <summary>
  /// Ожидает оплаты
  /// </summary>
  Unpaid = 1,
  
  /// <summary>
  /// Оплачено
  /// </summary>
  Paid
}
