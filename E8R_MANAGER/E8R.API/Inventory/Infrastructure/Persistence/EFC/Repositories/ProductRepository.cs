using E8R.API.Inventory.Domain.Model.Aggregates;
using E8R.API.Inventory.Domain.Repositories;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace E8R.API.Inventory.Infrastructure.Persistence.EFC.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task RemoveAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> FindByProductTypeIdAsync(int productTypeId)
    {
        return await _context.Products.Where(p => p.ProductTypeId == productTypeId).ToListAsync();
    }
}