using Karpenko.University.Backend.Application.Validation;
using static Karpenko.University.Backend.Domain.Order.OrderModel;
using CreateOrder = Karpenko.University.Backend.Application.UseCases.CreateOrder;

namespace Karpenko.University.Backend.Infrastructure.Validation;

/// <summary>
/// Валидатор данных для создания заказа
/// </summary>
internal sealed class CreateOrderEntryDataValidator : AbstractValidator<CreateOrder.EntryData> {
  /// <inheritdoc />
  protected override void ValidateModel(CreateOrder.EntryData model) {
    StringValidator(nameof(model.Description), model.Description)
      .Must(value => value is null || value.Length <= DescriptionMaxLength,
        $"Длинна комментария не должна превышать {DescriptionMaxLength} символов");
  }
}
