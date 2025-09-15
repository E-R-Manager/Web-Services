using E8R.API.Inventory.Domain.Model.Aggregates;
using E8R.API.Inventory.Domain.Model.Queries;
using E8R.API.Inventory.Domain.Repositories;
using E8R.API.Inventory.Domain.Services;

namespace E8R.API.Inventory.Application.Internal.QueryServices;

public class ProductQueryService(IProductRepository productRepository) : IProductQueryService
{
    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        return await productRepository.FindByIdAsync(query.ProductId);
    }
    
    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query)
    {
        return await productRepository.ListAsync();
    }
    
    public async Task<IEnumerable<Product>> Handle(GetProductsByProductTypeIdQuery query)
    {
        return await productRepository.FindByProductTypeIdAsync(query.ProductTypeId);
    }
}
