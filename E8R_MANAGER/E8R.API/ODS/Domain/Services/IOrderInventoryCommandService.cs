using E8R.API.ODS.Domain.Model.Entities;
using E8R.API.ODS.Domain.Model.Commands;

namespace E8R.API.ODS.Domain.Services;

public interface IOrderInventoryCommandService
{
    Task<OrderInventory?> Handle(CreateOrderInventoryCommand command);
    Task<OrderInventory?> Handle(UpdateOrderInventoryCommand command);
    Task<bool> Handle(DeleteOrderInventoryCommand command);
}