namespace E8R.API.Inventory.Interfaces.REST.Resources;

public record CreateProductResource(
    int ProductTypeId,
    string Name,
    int Stock,
    float Price,
    int QuantitySold
);