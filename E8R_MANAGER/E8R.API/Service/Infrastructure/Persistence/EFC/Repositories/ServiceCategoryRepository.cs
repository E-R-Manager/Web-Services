using E8R.API.Service.Domain.Model.Aggregates;
using E8R.API.Service.Domain.Repositories;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace E8R.API.Service.Infrastructure.Persistence.EFC.Repositories;

public class ServiceCategoryRepository : BaseRepository<ServiceCategory>, IServiceCategoryRepository
{
    private readonly AppDbContext _context;
    public ServiceCategoryRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task RemoveAsync(ServiceCategory serviceCategory)
    {
        _context.ServiceCategories.Remove(serviceCategory);
        await _context.SaveChangesAsync();
    }
}