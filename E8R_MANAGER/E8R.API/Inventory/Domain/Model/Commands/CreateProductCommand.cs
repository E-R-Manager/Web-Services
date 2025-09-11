namespace E8R.API.Inventory.Domain.Model.Commands;

public record CreateProductCommand(
    int ProductTypeId,
    string Name,
    int Stock,
    float Price,
    int QuantitySold
    );