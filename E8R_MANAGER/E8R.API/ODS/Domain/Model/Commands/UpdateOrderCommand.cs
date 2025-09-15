using E8R.API.ODS.Domain.Model.ValueObjects;

namespace E8R.API.ODS.Domain.Model.Commands;

public record UpdateOrderCommand(
    int OrderId,
    int CustomerId,
    DateOnly OrderDate,
    OrderState OrderState
);