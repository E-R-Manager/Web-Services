namespace E8R.API.ODS.Domain.Model.Commands;

public record CreateOrderServiceCommand(
    int OrderId,
    int ServiceId,
    string ServiceCategoryName,
    string ServiceTypeName,
    string Details,
    float Price
    );