using E8R.API.Inventory.Domain.Model.Entities;
using E8R.API.Inventory.Domain.Repositories;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace E8R.API.Inventory.Infrastructure.Persistence.EFC.Repositories;

public class ProductTypeRepository : BaseRepository<ProductType>, IProductTypeRepository
{
    private readonly AppDbContext _context;
    
    public ProductTypeRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task RemoveAsync(ProductType productType)
    {
        _context.ProductTypes.Remove(productType);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProductType>> FindByProductCategoryIdAsync(int productCategoryId)
    {
        return await _context.ProductTypes.Where(pt => pt.ProductCategoryId == productCategoryId).ToListAsync();
    }
}