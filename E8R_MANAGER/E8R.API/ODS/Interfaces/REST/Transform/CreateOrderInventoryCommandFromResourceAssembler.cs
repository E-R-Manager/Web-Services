using E8R.API.ODS.Domain.Model.Commands;
using E8R.API.ODS.Interfaces.REST.Resources;

namespace E8R.API.ODS.Interfaces.REST.Transform;

public static class CreateOrderInventoryCommandFromResourceAssembler
{
    public static CreateOrderInventoryCommand ToCommandFromResource(CreateOrderInventoryResource resource)
    {
        return new CreateOrderInventoryCommand(
            resource.OrderId,
            resource.ProductId,
            resource.Quantity
        );
    }
}