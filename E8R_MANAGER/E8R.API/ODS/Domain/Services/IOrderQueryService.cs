using E8R.API.ODS.Domain.Model.Aggregates;
using E8R.API.ODS.Domain.Model.Queries;

namespace E8R.API.ODS.Domain.Services;

public interface IOrderQueryService
{
    Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query);
    Task<Order?> Handle(GetOrderByIdQuery query);
}