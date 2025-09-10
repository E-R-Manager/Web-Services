using E8R.API.Inventory.Domain.Model.Commands;
using E8R.API.Inventory.Interfaces.REST.Resources;

namespace E8R.API.Inventory.Interfaces.REST.Transform;

public static class DeleteProductCategoryCommandFromResourceAssembler
{
    public static DeleteProductCategoryCommand ToCommandFromResource(DeleteProductCategoryResource resource)
    {
        return new DeleteProductCategoryCommand(resource.ProductCategoryId);
    }
}