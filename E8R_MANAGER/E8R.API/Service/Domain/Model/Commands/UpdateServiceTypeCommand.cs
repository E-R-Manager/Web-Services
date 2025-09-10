namespace E8R.API.Service.Domain.Model.Commands;

public record UpdateServiceTypeCommand(
    int Id,
    string Name,
    int ServiceCategoryId
);