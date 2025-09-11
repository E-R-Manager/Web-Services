using E8R.API.Inventory.Domain.Model.Commands;
using E8R.API.Inventory.Interfaces.REST.Resources;

namespace E8R.API.Inventory.Interfaces.REST.Transform;

public static class DeleteProductTypeCommandFromResourceAssembler
{
    public static DeleteProductTypeCommand ToCommandFromResource(DeleteProductTypeResource resource)
    {
        return new DeleteProductTypeCommand(resource.ProductTypeId);
    }
}