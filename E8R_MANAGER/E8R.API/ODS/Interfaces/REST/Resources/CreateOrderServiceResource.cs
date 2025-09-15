namespace E8R.API.ODS.Interfaces.REST.Resources;

public record CreateOrderServiceResourceAh(
    int OrderId,
    int ServiceTypeId,
    string Details,
    float Price
);