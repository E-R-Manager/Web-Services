namespace E8R.API.Service.Domain.Model.Commands;

public record UpdateServiceCategoryCommand(
    int Id,
    string Name,
    int ContractedAmount
);