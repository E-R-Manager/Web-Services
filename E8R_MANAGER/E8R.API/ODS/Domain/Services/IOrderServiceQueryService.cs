using E8R.API.ODS.Domain.Model.Entities;
using E8R.API.ODS.Domain.Model.Queries;

namespace E8R.API.ODS.Domain.Services;

public interface IOrderServiceQueryService
{
    Task<IEnumerable<OrderService>> Handle(GetAllOrdersServiceQuery query);
    Task<OrderService?> Handle(GetOrderServiceByIdQuery query);
}