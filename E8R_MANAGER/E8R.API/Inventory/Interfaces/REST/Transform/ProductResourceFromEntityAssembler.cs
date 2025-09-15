using E8R.API.Inventory.Interfaces.REST.Resources;
using E8R.API.Inventory.Domain.Model.Aggregates;

namespace E8R.API.Inventory.Interfaces.REST.Transform;

public static class ProductResourceFromEntityAssembler
{
    public static ProductResource ToResourceFromEntity(Product entity)
    {
        return new ProductResource(
            entity.Id,
            entity.ProductTypeId,
            entity.ProductTypeName,
            entity.ProductCategoryName,
            entity.Name,
            entity.Stock,
            entity.Price,
            entity.QuantitySold
        );
    }
}