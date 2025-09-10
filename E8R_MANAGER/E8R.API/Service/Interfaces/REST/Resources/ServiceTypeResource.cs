namespace E8R.API.Service.Interfaces.REST.Resources;

public record ServiceTypeResource(
    int Id,
    string Name,
    int ServiceCategoryId
    );