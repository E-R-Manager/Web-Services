namespace E8R.API.Service.Domain.Model.Commands;

public record UpdateServiceTypeCommand(
    int ServiceTypeId,
    string Name
);