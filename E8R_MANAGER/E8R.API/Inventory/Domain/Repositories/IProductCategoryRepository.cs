using E8R.API.Shared.Domain.Repositories;
using E8R.API.Inventory.Domain.Model.Entities;

namespace E8R.API.Inventory.Domain.Repositories;

public interface IProductCategoryRepository : IBaseRepository<ProductCategory>
{
    Task RemoveAsync(ProductCategory productCategory);
}