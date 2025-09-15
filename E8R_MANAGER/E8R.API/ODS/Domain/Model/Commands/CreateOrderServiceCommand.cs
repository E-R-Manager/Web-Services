namespace E8R.API.ODS.Domain.Model.Commands;

public record CreateOrderServiceCommand(
    int OrderId,
    int ServiceTypeId,
    string Details,
    float Price
    );