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
}