using E8R.API.Service.Domain.Model.Entities;
using E8R.API.Service.Domain.Repositories;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace E8R.API.Service.Infrastructure.Persistence.EFC.Repositories;

public class ServiceTypeRepository : BaseRepository<ServiceType>, IServiceTypeRepository
{
    private readonly AppDbContext _context;
    public ServiceTypeRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task RemoveAsync(ServiceType serviceType)
    {
        _context.ServiceTypes.Remove(serviceType);
        await _context.SaveChangesAsync();
    }
}