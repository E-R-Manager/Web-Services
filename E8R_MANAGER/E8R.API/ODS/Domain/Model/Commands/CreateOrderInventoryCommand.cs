namespace E8R.API.ODS.Domain.Model.Commands;

public record CreateOrderInventoryCommand(
    int OrderId,
    int ProductId,
    int Quantity
    );