using E8R.API.Inventory.Domain.Model.Entities;
using E8R.API.Inventory.Domain.Model.Queries;
using E8R.API.Inventory.Domain.Repositories;
using E8R.API.Inventory.Domain.Services;

namespace E8R.API.Inventory.Application.Internal.QueryServices;

public class ProductTypeQueryService(IProductTypeRepository productTypeRepository) : IProductTypeQueryService
{
    public async Task<ProductType?> Handle(GetProductTypeByIdQuery query)
    {
        return await productTypeRepository.FindByIdAsync(query.ProductTypeId);
    }

    public async Task<IEnumerable<ProductType>> Handle(GetAllProductTypesQuery query)
    {
        return await productTypeRepository.ListAsync();
    }
}
