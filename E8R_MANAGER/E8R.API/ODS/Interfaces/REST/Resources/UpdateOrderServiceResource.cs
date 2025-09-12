namespace E8R.API.ODS.Interfaces.REST.Resources;

public record UpdateOrderServiceResource(
    int ServiceId,
    string ServiceCategoryName,
    string ServiceTypeName,
    string Details,
    float Price
    );