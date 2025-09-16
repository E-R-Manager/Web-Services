using E8R.API.Shared.Domain.Repositories;
using E8R.API.ODS.Domain.Model.Entities;

namespace E8R.API.ODS.Domain.Repositories;

public interface IOrderInventoryRepository : IBaseRepository<OrderInventory>
{
    Task RemoveAsync(OrderInventory orderInventory);
    Task<IEnumerable<OrderInventory>> FindByProductIdAsync(int productId);
}