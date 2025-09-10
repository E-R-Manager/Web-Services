namespace E8R.API.Inventory.Interfaces.REST.Resources;

public record ProductResource(
    int Id,
    int ProductTypeId,
    string Name,
    int Stock,
    float Price,
    int QuantitySold);