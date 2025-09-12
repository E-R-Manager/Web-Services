using E8R.API.ODS.Domain.Model.Aggregates;
using E8R.API.ODS.Domain.Model.Commands;
using E8R.API.Service.Domain.Model.Entities;

namespace E8R.API.ODS.Domain.Model.Entities;

public class OrderService
{
    public OrderService()
    {
        Order = new Order();
        Service = new ServiceType();
        ServiceCategoryName = string.Empty;
        ServiceTypeName = string.Empty;
        Details = string.Empty;
        Price = 0;
    }
    
    public OrderService(
        Order order, 
        int orderId, 
        ServiceType service, 
        int serviceId,
        string serviceCategoryName,
        string serviceTypeName,
        string details,
        float price)
    {
        Order = order;
        OrderId = orderId;
        Service = service;
        ServiceId = serviceId;
        ServiceCategoryName = serviceCategoryName;
        ServiceTypeName = serviceTypeName;
        Details = details;
        Price = price;
    }

    public OrderService(CreateOrderServiceCommand command, Order order, ServiceType service)
    {
        Order = order;
        OrderId = order.Id;
        Service = service;
        ServiceId = service.Id;
        ServiceCategoryName = service.ServiceCategory.Name;
        ServiceTypeName = service.Name;
        Details = command.Details;
        Price = command.Price;
    }
    
    public int Id { get; set; }
    public Order Order { get; internal set; }
    public int OrderId { get; internal set; }
    public ServiceType Service { get; internal set; }
    public int ServiceId { get; internal set; }
    public string ServiceCategoryName { get; internal set; }
    public string ServiceTypeName { get; internal set; }
    public string Details { get; internal set; }
    public float Price { get; internal set; }
}