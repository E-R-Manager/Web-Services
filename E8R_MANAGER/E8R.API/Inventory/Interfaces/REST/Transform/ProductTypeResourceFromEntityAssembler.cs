using E8R.API.Inventory.Interfaces.REST.Resources;
using E8R.API.Inventory.Domain.Model.Entities;

namespace E8R.API.Inventory.Interfaces.REST.Transform;

public static class ProductTypeResourceFromEntityAssembler
{
    public static ProductTypeResource ToResourceFromEntity(ProductType entity)
    {
        return new ProductTypeResource(
            entity.Id,
            entity.Name,
            entity.ProductCategoryId
        );
    }
}