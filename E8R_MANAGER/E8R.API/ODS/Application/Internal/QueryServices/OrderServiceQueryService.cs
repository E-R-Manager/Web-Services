using E8R.API.ODS.Domain.Model.Entities;
using E8R.API.ODS.Domain.Model.Queries;
using E8R.API.ODS.Domain.Repositories;
using E8R.API.ODS.Domain.Services;

namespace E8R.API.ODS.Application.Internal.QueryServices;

public class OrderServiceQueryService(IOrderServiceRepository orderServiceRepository) : IOrderServiceQueryService
{
    public async Task<OrderService?> Handle(GetOrderServiceByIdQuery query)
    {
        return await orderServiceRepository.FindByIdAsync(query.OrderServiceId);
    }

    public async Task<IEnumerable<OrderService>> Handle(GetAllOrdersServiceQuery query)
    {
        return await orderServiceRepository.ListAsync();
    }
}
