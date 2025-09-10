using E8R.API.Shared.Domain.Repositories;
using E8R.API.Inventory.Domain.Model.Entities;

namespace E8R.API.Inventory.Domain.Repositories;

public interface IProductTypeRepository : IBaseRepository<ProductType>
{
    Task RemoveAsync(ProductType productType);
}