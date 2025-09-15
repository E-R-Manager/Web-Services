using E8R.API.ODS.Domain.Model.ValueObjects;

namespace E8R.API.ODS.Domain.Model.Commands;

public record CreateOrderCommand(
    int CustomerId,
    DateOnly OrderDate,
    OrderState OrderState
    );