using E8R.API.ODS.Domain.Model.Entities;
using E8R.API.ODS.Domain.Repositories;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace E8R.API.ODS.Infrastructure.Persistence.EFC.Repositories;

public class OrderInventoryRepository : BaseRepository<OrderInventory>, IOrderInventoryRepository
{
    private readonly AppDbContext _context;

    public OrderInventoryRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task RemoveAsync(OrderInventory orderInventory)
    {
        _context.OrderInventories.Remove(orderInventory);
        await _context.SaveChangesAsync();
    }
}