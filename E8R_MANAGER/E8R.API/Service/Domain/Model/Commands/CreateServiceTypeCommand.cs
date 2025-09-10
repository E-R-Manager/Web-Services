namespace E8R.API.Service.Domain.Model.Commands;

public record CreateServiceTypeCommand(
    string Name,
    int ServiceCategoryId
    );