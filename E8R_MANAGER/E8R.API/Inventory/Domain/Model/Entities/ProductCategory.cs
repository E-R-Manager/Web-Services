using E8R.API.Inventory.Domain.Model.Commands;

namespace E8R.API.Inventory.Domain.Model.Entities;

public class ProductCategory
{
    public ProductCategory()
    {
        Name = string.Empty;
    }
    
    public ProductCategory(string name)
    {
        Name = name;
    }
    
    public ProductCategory(CreateProductCategoryCommand command)
    {
        Name = command.Name;
    }
    
    
    public int Id { get; set; }
    public string Name { get; internal set; }
}