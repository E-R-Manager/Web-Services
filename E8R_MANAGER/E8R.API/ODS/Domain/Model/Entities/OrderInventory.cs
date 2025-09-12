using E8R.API.ODS.Domain.Model.Commands;
using E8R.API.ODS.Domain.Model.Aggregates;
using E8R.API.Inventory.Domain.Model.Aggregates;

namespace E8R.API.ODS.Domain.Model.Entities;

public class OrderInventory
{
    public OrderInventory()
    {
        Order = new Order();
        Product = new Product();
        ProductName = string.Empty;
        ProductPrice = 0;
        Quantity = 0;
    }

    public OrderInventory(
        Order order, 
        int orderId, 
        Product product, 
        int productId,
        string productName,
        float productPrice,
        int quantity)
    {
        Order = order;
        OrderId = orderId;
        Product = product;
        ProductId = productId;
        ProductName = productName;
        ProductPrice = productPrice;
        Quantity = quantity;
    }

    public OrderInventory(CreateOrderInventoryCommand command, Order order, Product product)
    {
        Order = order;
        OrderId = order.Id;
        Product = product;
        ProductId = product.Id;
        ProductName = product.Name;
        ProductPrice = product.Price;
        Quantity = command.Quantity;
    }
    
    public int Id { get; set; }
    public Order Order { get; internal set; }
    public int OrderId { get; internal set; }
    public Product Product { get; internal set; }
    public int ProductId { get; internal set; }
    public string ProductName { get; internal set; }
    public float ProductPrice { get; internal set; }
    public int Quantity { get; internal set; }
}