namespace E8R.API.Service.Domain.Model.Commands;

public record UpdateServiceCategoryCommand(
    int ServiceCategoryId,
    string Name,
    int ContractedAmount
);