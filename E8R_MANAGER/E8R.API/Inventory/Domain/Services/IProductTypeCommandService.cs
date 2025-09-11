using E8R.API.Inventory.Domain.Model.Entities;
using E8R.API.Inventory.Domain.Model.Commands;

namespace E8R.API.Inventory.Domain.Services;

public interface IProductTypeCommandService
{
    Task<ProductType?> Handle(CreateProductTypeCommand command);
    Task<ProductType?> Handle(UpdateProductTypeCommand command);
    Task<bool> Handle(DeleteProductTypeCommand command);
}