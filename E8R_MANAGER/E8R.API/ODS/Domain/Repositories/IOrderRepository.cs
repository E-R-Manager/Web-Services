using E8R.API.Shared.Domain.Repositories;
using E8R.API.ODS.Domain.Model.Aggregates;

namespace E8R.API.ODS.Domain.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task RemoveAsync(Order order);
}