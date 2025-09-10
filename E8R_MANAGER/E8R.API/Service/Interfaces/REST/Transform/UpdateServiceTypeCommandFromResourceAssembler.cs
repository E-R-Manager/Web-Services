using E8R.API.Service.Domain.Model.Commands;
using E8R.API.Service.Interfaces.REST.Resources;
namespace E8R.API.Service.Interfaces.REST.Transform;

public static class UpdateServiceTypeCommandFromResourceAssembler
{
    public static UpdateServiceTypeCommand ToCommandFromResource(UpdateServiceTypeResource resource, int serviceTypeId)
    {
        return new UpdateServiceTypeCommand(
            serviceTypeId,
            resource.Name
        );
    }
}