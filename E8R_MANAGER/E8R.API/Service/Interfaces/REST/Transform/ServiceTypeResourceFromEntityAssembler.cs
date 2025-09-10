using E8R.API.Service.Domain.Model.Entities;
using E8R.API.Service.Interfaces.REST.Resources;

namespace E8R.API.Service.Interfaces.REST.Transform;

public static class ServiceTypeResourceFromEntityAssembler
{
    public static ServiceTypeResource ToResourceFromEntity(ServiceType entity)
    {
        return new ServiceTypeResource(
            entity.Id,
            entity.Name,
            entity.ServiceCategoryId
        );
    }
}