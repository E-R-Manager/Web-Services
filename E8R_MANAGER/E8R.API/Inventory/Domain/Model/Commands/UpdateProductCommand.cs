namespace E8R.API.Inventory.Domain.Model.Commands;

public record UpdateProductCommand(
    int ProductId,
    int ProductTypeId,
    string Name,
    int Stock,
    float Price,
    int QuantitySold
);