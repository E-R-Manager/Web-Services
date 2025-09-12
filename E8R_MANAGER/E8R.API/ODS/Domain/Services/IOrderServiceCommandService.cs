using E8R.API.ODS.Domain.Model.Entities;
using E8R.API.ODS.Domain.Model.Commands;

namespace E8R.API.ODS.Domain.Services;

public interface IOrderServiceCommandService
{
    Task<OrderService?> Handle(CreateOrderServiceCommand command);
    Task<OrderService?> Handle(UpdateOrderServiceCommand command);
    Task<bool> Handle(DeleteOrderServiceCommand command);
}