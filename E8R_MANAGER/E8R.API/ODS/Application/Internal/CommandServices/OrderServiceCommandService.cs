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
    IServiceCategoryRepository serviceCategoryRepository,
    IUnitOfWork unitOfWork) : IOrderServiceCommandService
{
    public async Task<OrderService?> Handle(CreateOrderServiceCommand command)
    {
        var serviceType = await serviceTypeRepository.FindByIdAsync(command.ServiceTypeId);
        if (serviceType == null)
        {
            throw new ArgumentException("ServiceType Id no encontrado.");
        }
        var serviceCategory = await serviceCategoryRepository.FindByIdAsync(serviceType.ServiceCategoryId);
        if (serviceCategory == null)
        {
            throw new ArgumentException("ServiceCategory Id no encontrado.");
        }
        var order = await orderRepository.FindByIdAsync(command.OrderId);
        if (order == null)
        {
            throw new ArgumentException("Order Id no encontrado.");
        }
        var orderService = new OrderService(command, order, serviceType);
        await orderServiceRepository.AddAsync(orderService);
        await unitOfWork.CompleteAsync();
        return orderService;
    }

    public async Task<OrderService?> Handle(UpdateOrderServiceCommand command)
    {
        var orderService = await orderServiceRepository.FindByIdAsync(command.OrderServiceId);
        if (orderService == null)
        {
            return null;
        }

        if (orderService.ServiceTypeId != command.ServiceTypeId)
        {
            var serviceType = await serviceTypeRepository.FindByIdAsync(command.ServiceTypeId);
            if (serviceType == null)
            {
                throw new ArgumentException("ServiceType Id no encontrado.");
            }
            orderService.ServiceTypeId = serviceType.Id;
            orderService.ServiceTypeName = serviceType.Name;
            
            var serviceCategory = await serviceCategoryRepository.FindByIdAsync(serviceType.ServiceCategoryId);
            if (serviceCategory == null)
            {
                throw new ArgumentException("ServiceCategory Id no encontrado.");
            }
            orderService.ServiceCategoryName = serviceCategory.Name;
        }
        orderService.Details = command.Details;
        orderService.Price = command.Price;
        
        await unitOfWork.CompleteAsync();
        return orderService;
    }

    public async Task<bool> Handle(DeleteOrderServiceCommand command)
    {
        var orderService = await orderServiceRepository.FindByIdAsync(command.OrderServiceId);
        if (orderService == null)
        {
            return false;
        }
        await orderServiceRepository.RemoveAsync(orderService);
        await unitOfWork.CompleteAsync();
        return true;
    }
}
