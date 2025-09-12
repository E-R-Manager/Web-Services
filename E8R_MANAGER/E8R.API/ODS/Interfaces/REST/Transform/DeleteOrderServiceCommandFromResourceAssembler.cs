using E8R.API.ODS.Domain.Model.Commands;
using E8R.API.ODS.Interfaces.REST.Resources;

namespace E8R.API.ODS.Interfaces.REST.Transform;

public static class DeleteOrderServiceCommandFromResourceAssembler
{
    public static DeleteOrderServiceCommand ToCommandFromResource(DeleteOrderServiceResource resource)
    {
        return new DeleteOrderServiceCommand(resource.OrderServiceId);
    }
}