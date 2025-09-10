namespace E8R.API.Inventory.Interfaces.REST.Resources;

public record CreateProductTypeResource(
    string Name,
    int ProductCategoryId);