using E8R.API.ODS.Domain.Model.Commands;
using E8R.API.ODS.Domain.Model.Aggregates;
using E8R.API.ODS.Domain.Repositories;
using E8R.API.Client.Domain.Repositories;
using E8R.API.ODS.Domain.Services;
using E8R.API.Shared.Domain.Repositories;

namespace E8R.API.ODS.Application.Internal.CommandServices;

public class OrderCommandService(
    IOrderRepository orderRepository,
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork) : IOrderCommandService
{
    public async Task<Order?> Handle(CreateOrderCommand command)
    {
        var customer = await customerRepository.FindByIdAsync(command.CustomerId);
        if (customer == null)
        {
            throw new ArgumentException("Customer Id no encontrado.");
        }
        var order = new Order(command, customer);
        await orderRepository.AddAsync(order);
        await unitOfWork.CompleteAsync();
        return order;
    }
    
    public async Task<Order?> Handle(UpdateOrderCommand command)
    {
        var order = await orderRepository.FindByIdAsync(command.OrderId);
        if (order == null)
        {
            return null;
        }
        order.CustomerId = command.CustomerId;
        order.CustomerName = command.CustomerName;
        order.CustomerDni = command.CustomerDni;
        order.CustomerPhoneNumber = command.CustomerPhoneNumber;
        order.CustomerAddress = command.CustomerAddress;
        order.OrderDate = command.OrderDate;
        order.OrderState = command.OrderState;

        await unitOfWork.CompleteAsync();
        return order;
    }

    public async Task<bool> Handle(DeleteOrderCommand command)
    {
        var order = await orderRepository.FindByIdAsync(command.OrderId);
        if (order == null)
        {
            return false;
        }
        await orderRepository.RemoveAsync(order);
        await unitOfWork.CompleteAsync();
        return true;
    }
}
