namespace E8R.API.ODS.Domain.Model.Commands;

public record UpdateOrderInventoryCommand(
    int OrderInventoryId,
    int ProductId,
    int Quantity
);