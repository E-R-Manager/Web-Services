using E8R.API.Inventory.Domain.Model.Commands;
using E8R.API.Inventory.Domain.Model.Entities;
using E8R.API.Inventory.Domain.Repositories;
using E8R.API.Inventory.Domain.Services;
using E8R.API.Shared.Domain.Repositories;

namespace E8R.API.Inventory.Application.Internal.CommandServices;

public class ProductCategoryCommandService(
    IProductCategoryRepository productCategoryRepository,
    IUnitOfWork unitOfWork) : IProductCategoryCommandService
{
    public async Task<ProductCategory?> Handle(CreateProductCategoryCommand command)
    {
        var productCategory = new ProductCategory(command);
        await productCategoryRepository.AddAsync(productCategory);
        await unitOfWork.CompleteAsync();
        return productCategory;
    }

    public async Task<ProductCategory?> Handle(UpdateProductCategoryCommand command)
    {
        var productCategory = await productCategoryRepository.FindByIdAsync(command.ProductCategoryId);
        if (productCategory == null)
        {
            return null;
        }
        productCategory.Name = command.Name;

        await unitOfWork.CompleteAsync();
        return productCategory;
    }

    public async Task<bool> Handle(DeleteProductCategoryCommand command)
    {
        var productCategory = await productCategoryRepository.FindByIdAsync(command.ProductCategoryId);
        if (productCategory == null)
        {
            return false;
        }
        await productCategoryRepository.RemoveAsync(productCategory);
        await unitOfWork.CompleteAsync();
        return true;
    }
}
