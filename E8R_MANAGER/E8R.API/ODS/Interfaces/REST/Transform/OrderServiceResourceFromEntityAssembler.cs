using E8R.API.ODS.Interfaces.REST.Resources;
using E8R.API.ODS.Domain.Model.Entities;

namespace E8R.API.ODS.Interfaces.REST.Transform;

public static class OrderServiceResourceFromEntityAssembler
{
    public static OrderServiceResource ToResourceFromEntity(OrderService entity)
    {
        return new OrderServiceResource(
            entity.Id,
            entity.OrderId,
            entity.ServiceTypeId,
            entity.ServiceCategoryName,
            entity.ServiceTypeName,
            entity.Details,
            entity.Price
        );
    }
}