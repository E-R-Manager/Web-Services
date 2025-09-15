using E8R.API.Shared.Domain.Repositories;
using E8R.API.Inventory.Domain.Model.Aggregates;

namespace E8R.API.Inventory.Domain.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    Task RemoveAsync(Product product);
    Task<IEnumerable<Product>> FindByProductTypeIdAsync(int productTypeId);
}