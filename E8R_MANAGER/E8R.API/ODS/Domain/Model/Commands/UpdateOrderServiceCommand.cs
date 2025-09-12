namespace E8R.API.ODS.Domain.Model.Commands;

public record UpdateOrderServiceCommand(
    int OrderServiceId,
    int ServiceId,
    string ServiceCategoryName,
    string ServiceTypeName,
    string Details,
    float Price
);