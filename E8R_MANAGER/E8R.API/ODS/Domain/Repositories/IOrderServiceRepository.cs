using E8R.API.Shared.Domain.Repositories;
using E8R.API.ODS.Domain.Model.Entities;

namespace E8R.API.ODS.Domain.Repositories;

public interface IOrderServiceRepository : IBaseRepository<OrderService>
{
    Task RemoveAsync(OrderService orderService);
    Task<IEnumerable<OrderService>> FindByServiceTypeIdAsync(int serviceTypeId);
}