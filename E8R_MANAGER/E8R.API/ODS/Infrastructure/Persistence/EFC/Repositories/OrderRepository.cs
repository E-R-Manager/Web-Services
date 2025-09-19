using E8R.API.ODS.Domain.Model.Aggregates;
using E8R.API.ODS.Domain.Repositories;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using E8R.API.ODS.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace E8R.API.ODS.Infrastructure.Persistence.EFC.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task RemoveAsync(Order order)
    {
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }
    public async Task<IEnumerable<Order>> FindByCustomerIdAsync(int customerId)
    {
        return await _context.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
    }
    
    public async Task<IEnumerable<Order>> FindByOrderDateAsync(int year, int? month, int? day)
    {
        var query = _context.Orders.AsQueryable();

        query = query.Where(o => o.OrderDate.Year == year);

        if (month.HasValue)
            query = query.Where(o => o.OrderDate.Month == month.Value);

        if (day.HasValue)
            query = query.Where(o => o.OrderDate.Day == day.Value);

        return await query.ToListAsync();
    }
    public async Task<IEnumerable<Order>> FindByOrderStateAsync(OrderState orderState)
    {
        return await _context.Orders.Where(o => o.OrderState == orderState).ToListAsync();
    }
    
    public async Task<(IEnumerable<Order> Orders, int TotalCount)> GetAllOrdersPaginationQueryAsync(int page, int pageSize)
    {
        var query = _context.Orders.AsQueryable();
        var totalCount = await query.CountAsync();
        var orders = await query
            .OrderBy(o => o.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (orders, totalCount);
    }

}