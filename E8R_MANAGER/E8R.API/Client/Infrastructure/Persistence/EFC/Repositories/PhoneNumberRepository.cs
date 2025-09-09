using E8R.API.Client.Domain.Model.Entities;
using E8R.API.Client.Domain.Repositories;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace E8R.API.Client.Infrastructure.Persistence.EFC.Repositories;

public class PhoneNumberRepository : BaseRepository<PhoneNumber>, IPhoneNumberRepository
{
    private readonly AppDbContext _context;

    public PhoneNumberRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<PhoneNumber>> FindByCustomerIdAsync(int customerId)
    {
        return await _context.PhoneNumbers.Where(a => a.CustomerId == customerId).ToListAsync();
    }
    
    public async Task RemoveAsync(PhoneNumber phoneNumber)
    {
        _context.PhoneNumbers.Remove(phoneNumber);
        await _context.SaveChangesAsync();
    }
    
}