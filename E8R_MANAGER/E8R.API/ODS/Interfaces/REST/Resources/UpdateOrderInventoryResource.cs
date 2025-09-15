namespace E8R.API.ODS.Interfaces.REST.Resources;

public record UpdateOrderInventoryResource(
    int ProductId,
    int Quantity
    );