namespace E8R.API.Inventory.Domain.Model.Commands;

public record UpdateProductTypeCommand(
    int ProductTypeId,
    string Name
);