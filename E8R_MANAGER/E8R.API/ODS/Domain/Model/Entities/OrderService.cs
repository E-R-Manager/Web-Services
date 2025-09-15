using E8R.API.ODS.Domain.Model.Aggregates;
using E8R.API.ODS.Domain.Model.Commands;
using E8R.API.Service.Domain.Model.Entities;

namespace E8R.API.ODS.Domain.Model.Entities;

public class OrderService
{
    public OrderService()
    {
        Order = new Order();
        ServiceType = new ServiceType();
        ServiceCategoryName = string.Empty;
        ServiceTypeName = string.Empty;
        Details = string.Empty;
        Price = 0;
    }
    
    public OrderService(
        Order order, 
        int orderId, 
        ServiceType serviceType, 
        int serviceTypeId,
        string serviceCategoryName,
        string serviceTypeName,
        string details,
        float price)
    {
        Order = order;
        OrderId = orderId;
        ServiceType = serviceType;
        ServiceTypeId = serviceTypeId;
        ServiceCategoryName = serviceCategoryName;
        ServiceTypeName = serviceTypeName;
        Details = details;
        Price = price;
    }

    public OrderService(CreateOrderServiceCommand command, Order order, ServiceType serviceType)
    {
        Order = order;
        OrderId = order.Id;
        ServiceType = serviceType;
        ServiceTypeId = serviceType.Id;
        ServiceCategoryName = serviceType.ServiceCategory.Name;
        ServiceTypeName = serviceType.Name;
        Details = command.Details;
        Price = command.Price;
    }
    
    public int Id { get; set; }
    public Order Order { get; internal set; }
    public int OrderId { get; internal set; }
    public ServiceType ServiceType { get; internal set; }
    public int ServiceTypeId { get; internal set; }
    public string ServiceCategoryName { get; internal set; }
    public string ServiceTypeName { get; internal set; }
    public string Details { get; internal set; }
    public float Price { get; internal set; }
}