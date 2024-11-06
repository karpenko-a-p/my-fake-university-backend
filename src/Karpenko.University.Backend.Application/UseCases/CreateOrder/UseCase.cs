using Karpenko.University.Backend.Application.Validation;
using Karpenko.University.Backend.Core.ResultPattern;

namespace Karpenko.University.Backend.Application.UseCases.CreateOrder;

/// <summary>
/// Сценарий создания заказа
/// </summary>
public sealed class UseCase(
  IValidator<EntryData> entryDataValidator,
  IOrderRepository orderRepository
) : AbstractAsyncUseCase<EntryData> {
  /// <inheritdoc />
  public override async Task<IResult> ExecuteAsync(CancellationToken cancellationToken) {
    var validationResult = entryDataValidator.Validate(EntryData);

    if (validationResult.IsFailure)
      return new Validation.Results.ValidationFailure(validationResult);

    var alreadyBought = await orderRepository.CheckIfAlreadyBoughtAsync(
      EntryData.Student.Id,
      EntryData.Course.Id,
      cancellationToken);

    if (alreadyBought)
      return new Results.AlreadyBought();

    var createOrderDto = new CreateOrderDto(
      EntryData.Course,
      EntryData.Student,
      EntryData.Description);

    var createdOrder = await orderRepository.CreateOrderAsync(createOrderDto, cancellationToken);

    return new Results.Created(createdOrder);
  }
}
