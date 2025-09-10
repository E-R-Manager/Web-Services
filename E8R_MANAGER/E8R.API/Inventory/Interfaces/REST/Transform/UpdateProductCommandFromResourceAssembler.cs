using E8R.API.Inventory.Domain.Model.Commands;
using E8R.API.Inventory.Interfaces.REST.Resources;

namespace E8R.API.Inventory.Interfaces.REST.Transform;

public static class UpdateProductCommandFromResourceAssembler
{
    public static UpdateProductCommand ToCommandFromResource(UpdateProductResource resource, int productId)
    {
        return new UpdateProductCommand(
            productId,
            resource.ProductTypeId,
            resource.Name,
            resource.Stock,
            resource.Price,
            resource.QuantitySold
        );
    }
}