using E8R.API.ODS.Interfaces.REST.Resources;
using E8R.API.ODS.Domain.Model.Aggregates;

namespace E8R.API.ODS.Interfaces.REST.Transform;

public static class OrderResourceFromEntityAssembler
{
    public static OrderResource ToResourceFromEntity(Order entity)
    {
        return new OrderResource(
            entity.Id,
            entity.CustomerId,
            entity.CustomerName,
            entity.CustomerDni,
            entity.CustomerPhoneNumber,
            entity.CustomerAddress,
            entity.OrderDate,
            entity.OrderState
        );
    }
}