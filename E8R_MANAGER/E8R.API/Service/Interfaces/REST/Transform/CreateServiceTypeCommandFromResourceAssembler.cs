using E8R.API.Service.Domain.Model.Commands;
using E8R.API.Service.Interfaces.REST.Resources;

namespace E8R.API.Service.Interfaces.REST.Transform;

public static class CreateServiceTypeCommandFromResourceAssembler
{
    public static CreateServiceTypeCommand ToCommandFromResource(CreateServiceTypeResource resource)
    {
        return new CreateServiceTypeCommand(
            resource.Name,
            resource.ServiceCategoryId
        );
    }
}