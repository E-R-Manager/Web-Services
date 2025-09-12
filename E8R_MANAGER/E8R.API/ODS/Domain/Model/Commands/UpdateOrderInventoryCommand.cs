namespace E8R.API.ODS.Domain.Model.Commands;

public record UpdateOrderInventoryCommand(
    int OrderInventoryId,
    int ProductId,
    string ProductName,
    float ProductPrice,
    int Quantity
);