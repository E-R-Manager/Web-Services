namespace E8R.API.Inventory.Interfaces.REST.Resources;

public record ProductTypeResource(
    int Id,
    string Name,
    int ProductCategoryId
);