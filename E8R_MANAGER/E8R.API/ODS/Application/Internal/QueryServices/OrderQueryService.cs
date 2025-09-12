using E8R.API.ODS.Domain.Model.Aggregates;
using E8R.API.ODS.Domain.Model.Queries;
using E8R.API.ODS.Domain.Repositories;
using E8R.API.ODS.Domain.Services;

namespace E8R.API.ODS.Application.Internal.QueryServices;

public class OrderQueryService(IOrderRepository orderRepository) : IOrderQueryService
{
    public async Task<Order?> Handle(GetOrderByIdQuery query)
    {
        return await orderRepository.FindByIdAsync(query.OrderId);
    }

    public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query)
    {
        return await orderRepository.ListAsync();
    }
}
