namespace E8R.API.ODS.Interfaces.REST.Resources;

public record CreateOrderServiceResourceAh(
    int OrderId,
    int ServiceId,
    string ServiceCategoryName,
    string ServiceTypeName,
    string Details,
    float Price
);