using E8R.API.ODS.Domain.Model.Entities;
using E8R.API.ODS.Domain.Model.Queries;
using E8R.API.ODS.Domain.Repositories;
using E8R.API.ODS.Domain.Services;

namespace E8R.API.ODS.Application.Internal.QueryServices;

public class OrderInventoryQueryService(IOrderInventoryRepository orderInventoryRepository) : IOrderInventoryQueryService
{
    public async Task<OrderInventory?> Handle(GetOrderInventoryByIdQuery query)
    {
        return await orderInventoryRepository.FindByIdAsync(query.OrderInventoryId);
    }

    public async Task<IEnumerable<OrderInventory>> Handle(GetAllOrdersInventoryQuery query)
    {
        return await orderInventoryRepository.ListAsync();
    }
}
