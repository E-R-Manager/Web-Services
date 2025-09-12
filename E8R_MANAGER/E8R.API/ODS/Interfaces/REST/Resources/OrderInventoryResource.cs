namespace E8R.API.ODS.Interfaces.REST.Resources;

public record OrderInventoryResource(
    int Id,
    int OrderId,
    int ProductId,
    string ProductName,
    float ProductPrice,
    int Quantity
);