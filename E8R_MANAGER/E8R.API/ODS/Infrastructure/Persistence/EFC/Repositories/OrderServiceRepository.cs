using E8R.API.ODS.Domain.Model.Entities;
using E8R.API.ODS.Domain.Repositories;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace E8R.API.ODS.Infrastructure.Persistence.EFC.Repositories;

public class OrderServiceRepository : BaseRepository<OrderService>, IOrderServiceRepository
{
    private readonly AppDbContext _context;

    public OrderServiceRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task RemoveAsync(OrderService orderService)
    {
        _context.OrderServices.Remove(orderService);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<OrderService>> FindByServiceTypeIdAsync(int serviceTypeId)
    {
        return await _context.OrderServices.Where(os => os.ServiceTypeId == serviceTypeId).ToListAsync();
    }
}