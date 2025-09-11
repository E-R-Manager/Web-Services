using E8R.API.Inventory.Domain.Model.Commands;
using E8R.API.Inventory.Domain.Model.Entities;
using E8R.API.Inventory.Domain.Repositories;
using E8R.API.Inventory.Domain.Services;
using E8R.API.Shared.Domain.Repositories;

namespace E8R.API.Inventory.Application.Internal.CommandServices;

public class ProductTypeCommandService(
    IProductTypeRepository productTypeRepository,
    IProductCategoryRepository productCategoryRepository,
    IUnitOfWork unitOfWork) : IProductTypeCommandService
{
    public async Task<ProductType?> Handle(CreateProductTypeCommand command)
    {
        var productCategory = await productCategoryRepository.FindByIdAsync(command.ProductCategoryId);
        if (productCategory == null)
        {
            throw new ArgumentException("ProductCategory Id no encontrado.");
        }
        var productType = new ProductType(command, productCategory);
        await productTypeRepository.AddAsync(productType);
        await unitOfWork.CompleteAsync();
        return productType;
    }

    public async Task<ProductType?> Handle(UpdateProductTypeCommand command)
    {
        var productType = await productTypeRepository.FindByIdAsync(command.ProductTypeId);
        if (productType == null)
        {
            return null;
        }
        productType.Name = command.Name;
        
        await unitOfWork.CompleteAsync();
        return productType;
    }

    public async Task<bool> Handle(DeleteProductTypeCommand command)
    {
        var productType = await productTypeRepository.FindByIdAsync(command.ProductTypeId);
        if (productType == null)
        {
            return false;
        }
        await productTypeRepository.RemoveAsync(productType);
        await unitOfWork.CompleteAsync();
        return true;
    }
}
