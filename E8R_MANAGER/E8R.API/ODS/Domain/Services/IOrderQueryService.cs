using E8R.API.ODS.Domain.Model.Aggregates;
using E8R.API.ODS.Domain.Model.Queries;

namespace E8R.API.ODS.Domain.Services;

public interface IOrderQueryService
{
    Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query);
    Task<Order?> Handle(GetOrderByIdQuery query);
    Task <IEnumerable<Order>> Handle (GetOrdersByCustomerIdQuery query);
    Task <IEnumerable<Order>> Handle (GetOrdersByOrderDateQuery query);
    Task <IEnumerable<Order>> Handle (GetOrdersByOrderStateQuery query);
}