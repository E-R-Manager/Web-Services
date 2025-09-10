namespace E8R.API.Service.Interfaces.REST.Resources;

public record UpdateServiceCategoryResource(
    string Name,
    int ContractedAmount
);