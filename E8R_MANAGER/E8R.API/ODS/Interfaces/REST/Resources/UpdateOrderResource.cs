using E8R.API.ODS.Domain.Model.ValueObjects;

namespace E8R.API.ODS.Interfaces.REST.Resources;

public record UpdateOrderResource(
    int CustomerId,
    string CustomerName,
    string CustomerDni,
    string CustomerPhoneNumber,
    string CustomerAddress,
    DateOnly OrderDate,
    OrderState OrderState
    );