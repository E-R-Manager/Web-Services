namespace E8R.API.Inventory.Domain.Model.Commands;

public record UpdateProductCategoryCommand(
    int ProductCategoryId,
    string Name
    );