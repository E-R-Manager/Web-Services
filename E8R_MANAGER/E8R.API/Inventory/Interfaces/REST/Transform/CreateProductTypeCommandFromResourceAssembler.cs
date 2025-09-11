using E8R.API.Inventory.Domain.Model.Commands;
using E8R.API.Inventory.Interfaces.REST.Resources;

namespace E8R.API.Inventory.Interfaces.REST.Transform;

public static class CreateProductTypeCommandFromResourceAssembler
{
    public static CreateProductTypeCommand ToCommandFromResource(CreateProductTypeResource resource)
    {
        return new CreateProductTypeCommand(
            resource.Name,
            resource.ProductCategoryId
        );
    }
}