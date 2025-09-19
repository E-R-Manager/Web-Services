using E8R.API.Shared.Domain.Repositories;
using E8R.API.ODS.Domain.Model.Aggregates;
using E8R.API.ODS.Domain.Model.ValueObjects;

namespace E8R.API.ODS.Domain.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task <IEnumerable<Order>> FindByCustomerIdAsync(int customerId);
    Task <IEnumerable<Order>> FindByOrderDateAsync(int year, int? month, int? day);
    Task <IEnumerable<Order>> FindByOrderStateAsync(OrderState orderState);
    Task<(IEnumerable<Order> Orders, int TotalCount)> GetAllOrdersPaginationQueryAsync(int page, int pageSize);
}