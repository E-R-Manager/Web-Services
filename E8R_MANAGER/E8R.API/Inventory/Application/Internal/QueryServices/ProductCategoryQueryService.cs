using E8R.API.Inventory.Domain.Model.Entities;
using E8R.API.Inventory.Domain.Model.Queries;
using E8R.API.Inventory.Domain.Repositories;
using E8R.API.Inventory.Domain.Services;

namespace E8R.API.Inventory.Application.Internal.QueryServices;

public class ProductCategoryQueryService(IProductCategoryRepository productCategoryRepository) : IProductCategoryQueryService
{
    public async Task<ProductCategory?> Handle(GetProductCategoryByIdQuery query)
    {
        return await productCategoryRepository.FindByIdAsync(query.ProductCategoryId);
    }

    public async Task<IEnumerable<ProductCategory>> Handle(GetAllProductCategoriesQuery query)
    {
        return await productCategoryRepository.ListAsync();
    }
}
