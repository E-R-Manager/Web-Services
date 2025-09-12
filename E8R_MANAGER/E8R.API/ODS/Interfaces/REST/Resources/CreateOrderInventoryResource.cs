namespace E8R.API.ODS.Interfaces.REST.Resources;

public record CreateOrderInventoryResource(
    int OrderId,
    int ProductId,
    string ProductName,
    float ProductPrice,
    int Quantity
);