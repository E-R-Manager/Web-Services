using E8R.API.Service.Domain.Model.Aggregates;
using E8R.API.Service.Domain.Model.Commands;

namespace E8R.API.Service.Domain.Model.Entities;

public class ServiceType
{
    public ServiceType()
    {
        Name = string.Empty;
        ServiceCategory = new ServiceCategory();
    }

    public ServiceType(string name, ServiceCategory category, int serviceCategoryId)
    {
        Name = name;
        ServiceCategory = category;
        ServiceCategoryId = serviceCategoryId;
    }

    public ServiceType(CreateServiceTypeCommand command, ServiceCategory serviceCategory)
    {
        Name = command.Name;
        ServiceCategory = serviceCategory;
        ServiceCategoryId = serviceCategory.Id;
    }
    
    public int Id { get; internal set; }
    public string Name { get; internal set; }
    public ServiceCategory ServiceCategory { get; internal set; }
    public int ServiceCategoryId { get; internal set; }
}