using E8R.API.Service.Domain.Model.Commands;
using E8R.API.Service.Interfaces.REST.Resources;

namespace E8R.API.Service.Interfaces.REST.Transform;

public static class DeleteServiceTypeCommandFromResourceAssembler
{
    public static DeleteServiceTypeCommand ToCommandFromResource(DeleteServiceTypeResource resource)
    {
        return new DeleteServiceTypeCommand(resource.ServiceTypeId);
    }
}