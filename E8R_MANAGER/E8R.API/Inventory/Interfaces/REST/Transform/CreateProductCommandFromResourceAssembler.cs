using E8R.API.Inventory.Domain.Model.Commands;
using E8R.API.Inventory.Interfaces.REST.Resources;

namespace E8R.API.Inventory.Interfaces.REST.Transform;

public static class CreateProductCommandFromResourceAssembler
{
    public static CreateProductCommand ToCommandFromResource(CreateProductResource resource)
    {
        return new CreateProductCommand(
            resource.ProductTypeId,
            resource.Name,
            resource.Stock,
            resource.Price,
            resource.QuantitySold
        );
    }
}