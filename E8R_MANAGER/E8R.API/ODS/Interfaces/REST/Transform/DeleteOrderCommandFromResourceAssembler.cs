using E8R.API.ODS.Domain.Model.Commands;
using E8R.API.ODS.Interfaces.REST.Resources;

namespace E8R.API.ODS.Interfaces.REST.Transform;

public static class DeleteOrderCommandFromResourceAssembler
{
    public static DeleteOrderCommand ToCommandFromResource(DeleteOrderResource resource)
    {
        return new DeleteOrderCommand(resource.OrderId);
    }
}