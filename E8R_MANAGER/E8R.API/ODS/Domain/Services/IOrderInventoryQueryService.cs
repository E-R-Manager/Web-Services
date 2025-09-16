using E8R.API.ODS.Domain.Model.Entities;
using E8R.API.ODS.Domain.Model.Queries;

namespace E8R.API.ODS.Domain.Services;

public interface IOrderInventoryQueryService
{
    Task<IEnumerable<OrderInventory>> Handle(GetAllOrdersInventoryQuery query);
    Task<OrderInventory?> Handle(GetOrderInventoryByIdQuery query);
    Task<IEnumerable<OrderInventory>> Handle(GetOrderInventoriesByProductIdQuery query);
}