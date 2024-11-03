using Karpenko.University.Backend.Domain.Order;

namespace Karpenko.University.Backend.API.Controllers.Order.Contracts;

/// <summary>
/// Контракт данных заказа
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Description">Комментарий к платежу</param>
/// <param name="Price">Стоимость</param>
/// <param name="Product">Контракт покупаемого товара для заказа</param>
/// <param name="Payer">Контракт плательщика заказа</param>
/// <param name="PaymentTime">Время оплаты</param>
public sealed record OrderContract(
  long Id,
  string Description,
  decimal Price,
  OrderProductContract Product,
  OrderPayerContract Payer,
  DateTime PaymentTime
) {
  /// <summary>
  /// Преобразование модели к контракту заказа
  /// </summary>
  public OrderContract(OrderModel order) : this(
    order.Id,
    order.Description,
    order.Price,
    new OrderProductContract(order.Product),
    new OrderPayerContract(order.Payer),
    order.PaymentTime) {}
}

/// <summary>
/// Контракт покупаемого товара для заказа
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Название</param>
public sealed record OrderProductContract(
  long Id,
  string Name
) {
  /// <summary>
  /// Преобразование модели к контракту покупаемого товара
  /// </summary>
  public OrderProductContract(OrderProduct product) : this(
    product.Id,
    product.Name) {} 
}

/// <summary>
/// Контракт плательщика заказа
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Имя</param>
/// <param name="Email">Почта</param>
public sealed record OrderPayerContract(
  long Id,
  string Name,
  string Email
) {
  /// <summary>
  /// Преобразование модели к контракту плательщика
  /// </summary>
  public OrderPayerContract(OrderPayer payer) : this(
    payer.Id,
    payer.Name,
    payer.Email) {}
}
