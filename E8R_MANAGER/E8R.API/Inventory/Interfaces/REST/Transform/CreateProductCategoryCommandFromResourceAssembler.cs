using E8R.API.Inventory.Domain.Model.Commands;
using E8R.API.Inventory.Interfaces.REST.Resources;

namespace E8R.API.Inventory.Interfaces.REST.Transform;

public static class CreateProductCategoryCommandFromResourceAssembler
{
    public static CreateProductCategoryCommand ToCommandFromResource(CreateProductCategoryResource resource)
    {
        return new CreateProductCategoryCommand(
            resource.Name
        );
    }
}