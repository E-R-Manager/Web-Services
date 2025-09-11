using E8R.API.Inventory.Interfaces.REST.Resources;
using E8R.API.Inventory.Domain.Model.Entities;

namespace E8R.API.Inventory.Interfaces.REST.Transform;

public static class ProductCategoryResourceFromEntityAssembler
{
    public static ProductCategoryResource ToResourceFromEntity(ProductCategory entity)
    {
        return new ProductCategoryResource(
            entity.Id,
            entity.Name
        );
    }
}