using E8R.API.ODS.Domain.Model.Aggregates;
using E8R.API.ODS.Domain.Model.Commands;

namespace E8R.API.ODS.Domain.Services;

public interface IOrderCommandService
{
    Task<Order?> Handle(CreateOrderCommand command);
    Task<Order?> Handle(UpdateOrderCommand command);
}