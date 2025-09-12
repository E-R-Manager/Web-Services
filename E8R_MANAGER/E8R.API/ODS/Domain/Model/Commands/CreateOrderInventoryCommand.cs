namespace E8R.API.ODS.Domain.Model.Commands;

public record CreateOrderInventoryCommand(
    int OrderId,
    int ProductId,
    string ProductName,
    float ProductPrice,
    int Quantity
    );