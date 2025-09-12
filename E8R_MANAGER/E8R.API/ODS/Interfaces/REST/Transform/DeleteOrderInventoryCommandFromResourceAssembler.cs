using E8R.API.ODS.Domain.Model.Commands;
using E8R.API.ODS.Interfaces.REST.Resources;

namespace E8R.API.ODS.Interfaces.REST.Transform;

public static class DeleteOrderInventoryCommandFromResourceAssembler
{
    public static DeleteOrderInventoryCommand ToCommandFromResource(DeleteOrderInventoryResource resource)
    {
        return new DeleteOrderInventoryCommand(resource.OrderInventoryId);
    }
}