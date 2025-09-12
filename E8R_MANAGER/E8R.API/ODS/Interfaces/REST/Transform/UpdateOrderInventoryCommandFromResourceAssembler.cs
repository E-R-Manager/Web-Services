using E8R.API.ODS.Domain.Model.Commands;
using E8R.API.ODS.Interfaces.REST.Resources;

namespace E8R.API.ODS.Interfaces.REST.Transform;

public static class UpdateOrderInventoryCommandFromResourceAssembler
{
    public static UpdateOrderInventoryCommand ToCommandFromResource(UpdateOrderInventoryResource resource, int orderInventoryId)
    {
        return new UpdateOrderInventoryCommand(
            orderInventoryId,
            resource.ProductId,
            resource.ProductName,
            resource.ProductPrice,
            resource.Quantity
        );
    }
}