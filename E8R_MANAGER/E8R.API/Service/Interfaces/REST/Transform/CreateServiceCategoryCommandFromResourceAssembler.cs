using E8R.API.Service.Domain.Model.Commands;
using E8R.API.Service.Interfaces.REST.Resources;

namespace E8R.API.Service.Interfaces.REST.Transform;

public static class CreateServiceCategoryCommandFromResourceAssembler
{
    public static CreateServiceCategoryCommand ToCommandFromResource(CreateServiceCategoryResource resource)
    {
        return new CreateServiceCategoryCommand(
            resource.Name,
            resource.ContractedAmount
        );
    }
}