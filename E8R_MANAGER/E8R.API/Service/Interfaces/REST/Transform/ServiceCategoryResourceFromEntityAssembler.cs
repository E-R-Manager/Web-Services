using E8R.API.Service.Domain.Model.Aggregates;
using E8R.API.Service.Interfaces.REST.Resources;

namespace E8R.API.Service.Interfaces.REST.Transform;

public static class ServiceCategoryResourceFromEntityAssembler
{
    public static ServiceCategoryResource ToResourceFromEntity(ServiceCategory entity)
    {
        return new ServiceCategoryResource(
            entity.Id,
            entity.Name,
            entity.ContractedAmount
        );
    }
}