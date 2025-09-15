using E8R.API.Service.Domain.Model.Commands;

namespace E8R.API.Service.Domain.Model.Aggregates;

public class ServiceCategory
{
    public ServiceCategory()
    {
        Name = string.Empty;
        ContractedAmount = 0;
    }

    public ServiceCategory(string name, int contractedAmount)
    {
        Name = name;
        ContractedAmount = contractedAmount;
    }

    public ServiceCategory(CreateServiceCategoryCommand categoryCommand)
    {
        Name = categoryCommand.Name;
    }

    public int Id { get; internal set; }
    public string Name { get; internal set; }
    public int ContractedAmount { get; internal set; }
}