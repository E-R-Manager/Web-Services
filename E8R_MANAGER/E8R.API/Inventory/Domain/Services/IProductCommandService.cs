using E8R.API.Inventory.Domain.Model.Aggregates;
using E8R.API.Inventory.Domain.Model.Commands;
namespace E8R.API.Inventory.Domain.Services;

public interface IProductCommandService
{
    Task<Product?> Handle(CreateProductCommand command);
    Task<Product?> Handle(UpdateProductCommand command);
    Task<bool> Handle(DeleteProductCommand command);
}