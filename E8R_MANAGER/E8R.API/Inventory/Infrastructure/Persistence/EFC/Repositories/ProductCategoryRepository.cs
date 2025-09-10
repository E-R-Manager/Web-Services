using E8R.API.Inventory.Domain.Model.Entities;
using E8R.API.Inventory.Domain.Repositories;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace E8R.API.Inventory.Infrastructure.Persistence.EFC.Repositories;

public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
{
    private readonly AppDbContext _context;
    public ProductCategoryRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task RemoveAsync(ProductCategory productCategory)
    {
        _context.ProductCategories.Remove(productCategory);
        await _context.SaveChangesAsync();
    }
}