using E8R.API.ODS.Domain.Model.ValueObjects;

namespace E8R.API.ODS.Domain.Model.Commands;

public record CreateOrderCommand(
    int CustomerId,
    string CustomerName,
    string CustomerDni,
    string CustomerPhoneNumber,
    string CustomerAddress,
    DateOnly OrderDate,
    OrderState OrderState
    );