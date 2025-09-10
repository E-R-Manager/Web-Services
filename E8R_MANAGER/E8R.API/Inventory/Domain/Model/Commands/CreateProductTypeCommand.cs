namespace E8R.API.Inventory.Domain.Model.Commands;

public record CreateProductTypeCommand(
    string Name,
    int ProductCategoryId
    );