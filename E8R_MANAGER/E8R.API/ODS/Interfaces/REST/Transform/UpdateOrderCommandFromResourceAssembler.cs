using E8R.API.ODS.Domain.Model.Commands;
using E8R.API.ODS.Interfaces.REST.Resources;

namespace E8R.API.ODS.Interfaces.REST.Transform;

public static class UpdateOrderCommandFromResourceAssembler
{
    public static UpdateOrderCommand ToCommandFromResource(UpdateOrderResource resource, int orderId)
    {
        return new UpdateOrderCommand(
            orderId,
            resource.CustomerId,
            resource.OrderDate,
            resource.OrderState
        );
    }
}