using E8R.API.Client.Domain.Model.Aggregates;
using E8R.API.Client.Domain.Repositories;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace E8R.API.Client.Infrastructure.Persistence.EFC.Repositories;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    private readonly AppDbContext _context;
    public CustomerRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task RemoveAsync(Customer customer)
    {
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }
    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.Customers.AnyAsync(c => c.Name == name);
    }
    
    public async Task<bool> ExistsByNameAsync(string name, int excludeId)
    {
        return await _context.Customers.AnyAsync(c => c.Name == name && c.Id != excludeId);
    }
    
    public async Task<bool> ExistsByDniAsync(string dni)
    {
        return await _context.Customers.AnyAsync(c => c.Dni == dni);
    }
    
    public async Task<bool> ExistsByDniAsync(string dni, int excludeId)
    {
        return await _context.Customers.AnyAsync(c => c.Dni == dni && c.Id != excludeId);
    }
    
    public async Task<bool> ExistsByRucAsync(string ruc)
    {
        return await _context.Customers.AnyAsync(c => c.Ruc == ruc);
    }
    
    public async Task<bool> ExistsByRucAsync(string ruc, int excludeId)
    {
        return await _context.Customers.AnyAsync(c => c.Ruc == ruc && c.Id != excludeId);
    }
    
    public async Task<IEnumerable<Customer>> FindByNameAsync(string name)
    {
        return await _context.Customers
            .Where(c => c.Name.Contains(name))
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Customer>> FindByDniAsync(string dni)
    {
        return await _context.Customers
            .Where(c => c.Dni.Contains(dni))
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Customer>> FindByRucAsync(string ruc)
    {
        return await _context.Customers
            .Where(c => c.Ruc.Contains(ruc))
            .ToListAsync();
    }
    
    public async Task<(IEnumerable<Customer> Customers, int TotalCount)> GetAllCustomersPaginationQueryAsync(int page, int pageSize)
    {
        var query = _context.Customers.AsQueryable();
        var totalCount = await query.CountAsync();
        var customers = await query
            .OrderBy(c => c.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (customers, totalCount);
    }
}