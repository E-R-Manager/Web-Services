namespace E8R.API.ODS.Domain.Model.Commands;

public record UpdateOrderServiceCommand(
    int OrderServiceId,
    int ServiceTypeId,
    string Details,
    float Price
);