namespace E8R.API.Service.Interfaces.REST.Resources;

public record CreateServiceTypeResource(
    string Name,
    int ServiceCategoryId
);