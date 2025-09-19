using E8R.API.Shared.Domain.Repositories;
using E8R.API.ODS.Domain.Model.Aggregates;
using E8R.API.ODS.Domain.Model.ValueObjects;

namespace E8R.API.ODS.Domain.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task RemoveAsync(Order order);
    Task <IEnumerable<Order>> FindByCustomerIdAsync(int customerId);
    Task <IEnumerable<Order>> FindByOrderDateAsync(DateOnly orderDate);
    Task <IEnumerable<Order>> FindByOrderStateAsync(OrderState orderState);
}