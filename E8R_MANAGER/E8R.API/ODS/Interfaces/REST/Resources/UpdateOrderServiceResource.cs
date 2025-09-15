namespace E8R.API.ODS.Interfaces.REST.Resources;

public record UpdateOrderServiceResource(
    int ServiceTypeId,
    string Details,
    float Price
    );