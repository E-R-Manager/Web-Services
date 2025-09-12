using E8R.API.ODS.Domain.Model.Commands;
using E8R.API.ODS.Domain.Model.Entities;
using E8R.API.ODS.Domain.Repositories;
using E8R.API.Inventory.Domain.Repositories;
using E8R.API.ODS.Domain.Services;
using E8R.API.Shared.Domain.Repositories;

namespace E8R.API.ODS.Application.Internal.CommandServices;

public class OrderInventoryCommandService(
    IOrderInventoryRepository orderInventoryRepository,
    IOrderRepository orderRepository,
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) : IOrderInventoryCommandService
{
    public async Task<OrderInventory?> Handle(CreateOrderInventoryCommand command)
    {
        var product = await productRepository.FindByIdAsync(command.ProductId);
        if (product == null)
        {
            throw new ArgumentException("Product Id no encontrado.");
        }
        var order = await orderRepository.FindByIdAsync(command.OrderId);
        if (order == null)
        {
            throw new ArgumentException("Order Id no encontrado.");
        }
        var orderInventory = new OrderInventory(command, order, product);
        await orderInventoryRepository.AddAsync(orderInventory);
        await unitOfWork.CompleteAsync();
        return orderInventory;
    }

    public async Task<OrderInventory?> Handle(UpdateOrderInventoryCommand command)
    {
        var orderInventory = await orderInventoryRepository.FindByIdAsync(command.OrderInventoryId);
        if (orderInventory == null)
        {
            return null;
        }
        var product = await productRepository.FindByIdAsync(command.ProductId);
        if (product == null)
        {
            throw new ArgumentException("Product Id no encontrado.");
        }
        orderInventory.ProductId = command.ProductId;
        orderInventory.ProductName = command.ProductName;
        orderInventory.ProductPrice = command.ProductPrice;
        orderInventory.Quantity = command.Quantity;

        await unitOfWork.CompleteAsync();
        return orderInventory;
    }

    public async Task<bool> Handle(DeleteOrderInventoryCommand command)
    {
        var orderInventory = await orderInventoryRepository.FindByIdAsync(command.OrderInventoryId);
        if (orderInventory == null)
        {
            return false;
        }
        await orderInventoryRepository.RemoveAsync(orderInventory);
        await unitOfWork.CompleteAsync();
        return true;
    }
}
