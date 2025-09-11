using E8R.API.Inventory.Domain.Model.Entities;
using E8R.API.Inventory.Domain.Model.Commands;

namespace E8R.API.Inventory.Domain.Model.Entities;

public class ProductType
{
    public ProductType()
    {
        Name = string.Empty;
        ProductCategory = new ProductCategory();
    }
    
    public ProductType(string name, ProductCategory productCategory, int productCategoryId)
    {
        Name = name;
        ProductCategory = productCategory;
        ProductCategoryId = productCategoryId;
    }
    
    public ProductType(CreateProductTypeCommand command, ProductCategory productCategory)
    {
        Name = command.Name;
        ProductCategory = productCategory;
        ProductCategoryId = productCategory.Id;
    }
    
    public int Id { get; set; }
    public string Name { get; internal set; }
    public ProductCategory ProductCategory { get; internal set; }
    public int ProductCategoryId { get; internal set; }
}