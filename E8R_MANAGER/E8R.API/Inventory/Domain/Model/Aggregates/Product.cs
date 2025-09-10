using E8R.API.Inventory.Domain.Model.Entities;
using E8R.API.Inventory.Domain.Model.Commands;

namespace E8R.API.Inventory.Domain.Model.Aggregates;

public class Product
{
    public Product()
    {
        ProductType = new ProductType();
        Name = string.Empty;
        Stock = 0;
        Price = 0;
        QuantitySold = 0;
    }

    public Product(ProductType productType, int productTypeId, string name, int stock, float price, int quantitySold)
    {
        ProductType = productType;
        ProductTypeId = productTypeId;
        Name = name;
        Stock = stock;
        Price = price;
        QuantitySold = quantitySold;
    }
    
    public Product(CreateProductCommand command, ProductType productType)
    {
        ProductType = productType;
        ProductTypeId = command.ProductTypeId;
        Name = command.Name;
        Stock = command.Stock;
        Price = command.Price;
        QuantitySold = command.QuantitySold;
    }
    
    public int Id { get; set; }
    public ProductType ProductType { get; internal set; }
    public int ProductTypeId { get; internal set; }
    public string Name { get; internal set; }
    public int Stock { get; internal set; }
    public float Price { get; internal set; }
    public int QuantitySold { get; internal set; }
}