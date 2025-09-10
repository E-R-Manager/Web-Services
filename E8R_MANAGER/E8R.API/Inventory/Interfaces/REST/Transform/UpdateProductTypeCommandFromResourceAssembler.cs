using E8R.API.Inventory.Domain.Model.Commands;
using E8R.API.Inventory.Interfaces.REST.Resources;

namespace E8R.API.Inventory.Interfaces.REST.Transform;

public static class UpdateProductTypeCommandFromResourceAssembler
{
    public static UpdateProductTypeCommand ToCommandFromResource(UpdateProductTypeResource resource, int productTypeId)
    {
        return new UpdateProductTypeCommand(
            productTypeId,
            resource.Name
        );
    }
}