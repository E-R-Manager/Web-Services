using E8R.API.Inventory.Domain.Model.Commands;
using E8R.API.Inventory.Interfaces.REST.Resources;

namespace E8R.API.Inventory.Interfaces.REST.Transform;

public static class UpdateProductCategoryCommandFromResourceAssembler
{
    public static UpdateProductCategoryCommand ToCommandFromResource(UpdateProductCategoryResource resource, int productCategoryId)
    {
        return new UpdateProductCategoryCommand(
            productCategoryId,
            resource.Name
        );
    }
}