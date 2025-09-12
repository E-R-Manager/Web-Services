using E8R.API.ODS.Domain.Model.Commands;
using E8R.API.ODS.Domain.Model.Entities;
using E8R.API.ODS.Domain.Repositories;
using E8R.API.Service.Domain.Repositories;
using E8R.API.ODS.Domain.Services;
using E8R.API.Shared.Domain.Repositories;

namespace E8R.API.ODS.Application.Internal.CommandServices;

public class OrderServiceCommandService(
    IOrderServiceRepository orderServiceRepository,
    IOrderRepository orderRepository,
    IServiceTypeRepository serviceTypeRepository,
    IUnitOfWork unitOfWork) : IOrderServiceCommandService
{
    public async Task<OrderService?> Handle(CreateOrderServiceCommand command)
    {
        var serviceType = await serviceTypeRepository.FindByIdAsync(command.ServiceId);
        if (serviceType == null)
        {
            throw new ArgumentException("ServiceType Id no encontrado.");
        }
        var order = await orderRepository.FindByIdAsync(command.OrderId);
        if (order == null)
        {
            throw new ArgumentException("Order Id no encontrado.");
        }
        var service = new OrderService(command, order, serviceType);
        await orderServiceRepository.AddAsync(service);
        await unitOfWork.CompleteAsync();
        return service;
    }

    public async Task<OrderService?> Handle(UpdateOrderServiceCommand command)
    {
        var service = await orderServiceRepository.FindByIdAsync(command.OrderServiceId);
        if (service == null)
        {
            return null;
        }
        var serviceType = await serviceTypeRepository.FindByIdAsync(command.ServiceId);
        if (serviceType == null)
        {
            throw new ArgumentException("ServiceType Id no encontrado.");
        }
        service.ServiceId = command.ServiceId;
        service.ServiceTypeName = command.ServiceTypeName;
        service.ServiceCategoryName = command.ServiceCategoryName;
        service.Details = command.Details;
        service.Price = command.Price;
        
        await unitOfWork.CompleteAsync();
        return service;
    }

    public async Task<bool> Handle(DeleteOrderServiceCommand command)
    {
        var service = await orderServiceRepository.FindByIdAsync(command.OrderServiceId);
        if (service == null)
        {
            return false;
        }
        await orderServiceRepository.RemoveAsync(service);
        await unitOfWork.CompleteAsync();
        return true;
    }
}
