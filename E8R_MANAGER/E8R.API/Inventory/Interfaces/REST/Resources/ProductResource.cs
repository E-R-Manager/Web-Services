namespace E8R.API.Inventory.Interfaces.REST.Resources;

public record ProductResource(
    int Id,
    int ProductTypeId,
    string ProductTypeName,
    string ProductCategoryName,
    string Name,
    int Stock,
    float Price,
    int QuantitySold);