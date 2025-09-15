namespace E8R.API.ODS.Interfaces.REST.Resources;

public record OrderServiceResource(
    int Id,
    int OrderId,
    int ServiceTypeId,
    string ServiceCategoryName,
    string ServiceTypeName,
    string Details,
    float Price
);