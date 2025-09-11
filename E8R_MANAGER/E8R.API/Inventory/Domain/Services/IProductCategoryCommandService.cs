using E8R.API.Inventory.Domain.Model.Entities;
using E8R.API.Inventory.Domain.Model.Commands;

namespace E8R.API.Inventory.Domain.Services;

public interface IProductCategoryCommandService
{
    Task<ProductCategory?> Handle(CreateProductCategoryCommand command);
    Task<ProductCategory?> Handle(UpdateProductCategoryCommand command);
    Task<bool> Handle(DeleteProductCategoryCommand command);
}