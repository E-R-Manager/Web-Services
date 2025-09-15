using E8R.API.Inventory.Domain.Model.Commands;
using E8R.API.Inventory.Domain.Model.Aggregates;
using E8R.API.Inventory.Domain.Repositories;
using E8R.API.Inventory.Domain.Services;
using E8R.API.Shared.Domain.Repositories;

namespace E8R.API.Inventory.Application.Internal.CommandServices;

public class ProductCommandService(
    IProductRepository productRepository,
    IProductTypeRepository productTypeRepository,
    IProductCategoryRepository productCategoryRepository,
    IUnitOfWork unitOfWork) : IProductCommandService
{
    public async Task<Product?> Handle(CreateProductCommand command)
    {
        var productType = await productTypeRepository.FindByIdAsync(command.ProductTypeId);
        if (productType == null)
        {
            throw new ArgumentException("ProductType Id no encontrado.");
        }
        var productCategory = await productCategoryRepository.FindByIdAsync(productType.ProductCategoryId);
        if (productCategory == null)
        {
            throw new ArgumentException("ProductCategory Id no encontrado.");
        }
        var product = new Product(command, productType);
        await productRepository.AddAsync(product);
        await unitOfWork.CompleteAsync();
        return product;
    }
    
    public async Task<Product?> Handle(UpdateProductCommand command)
    {
        var product = await productRepository.FindByIdAsync(command.ProductId);
        if (product == null)
        {
            return null;
        }

        if (product.ProductTypeId != command.ProductTypeId)
        {
            var productType = await productTypeRepository.FindByIdAsync(command.ProductTypeId);
            if (productType == null)
            {
                throw new ArgumentException("ProductType Id no encontrado.");
            }
            product.ProductTypeId = productType.Id;
            product.ProductTypeName = productType.Name;
            
            var productCategory = await productCategoryRepository.FindByIdAsync(productType.ProductCategoryId);
            if (productCategory == null)
            {
                throw new ArgumentException("ProductCategory Id no encontrado.");
            }
            product.ProductCategoryName = productCategory.Name;
        }
        
        product.Name = command.Name;
        product.Price = command.Price;
        product.Stock = command.Stock;
        product.QuantitySold = command.QuantitySold;

        await unitOfWork.CompleteAsync();
        return product;
    }

    public async Task<bool> Handle(DeleteProductCommand command)
    {
        var product = await productRepository.FindByIdAsync(command.ProductId);
        if (product == null)
        {
            return false;
        }
        await productRepository.RemoveAsync(product);
        await unitOfWork.CompleteAsync();
        return true;
    }
}
