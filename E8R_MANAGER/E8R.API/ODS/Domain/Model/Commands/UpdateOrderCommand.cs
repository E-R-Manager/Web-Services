using E8R.API.ODS.Domain.Model.ValueObjects;

namespace E8R.API.ODS.Domain.Model.Commands;

public record UpdateOrderCommand(
    int OrderId,
    int CustomerId,
    string CustomerName,
    string CustomerDni,
    string CustomerPhoneNumber,
    string CustomerAddress,
    DateOnly OrderDate,
    OrderState OrderState
);