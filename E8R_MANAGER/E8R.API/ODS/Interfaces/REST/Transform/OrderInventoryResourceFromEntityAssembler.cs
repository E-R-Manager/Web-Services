using E8R.API.ODS.Interfaces.REST.Resources;
using E8R.API.ODS.Domain.Model.Entities;

namespace E8R.API.ODS.Interfaces.REST.Transform;

public static class OrderInventoryResourceFromEntityAssembler
{
    public static OrderInventoryResource ToResourceFromEntity(OrderInventory entity)
    {
        return new OrderInventoryResource(
            entity.Id,
            entity.OrderId,
            entity.ProductId,
            entity.ProductName,
            entity.ProductPrice,
            entity.Quantity
        );
    }
}