using E8R.API.ODS.Domain.Model.ValueObjects;

namespace E8R.API.ODS.Interfaces.REST.Resources;

public record UpdateOrderResource(
    int CustomerId,
    DateOnly OrderDate,
    OrderState OrderState
    );