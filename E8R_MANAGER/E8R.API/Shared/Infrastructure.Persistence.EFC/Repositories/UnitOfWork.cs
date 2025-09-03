namespace E8R.API.Shared.Infrastructure.Persistence.EFC.Repositories;

using E8R.API.Shared.Domain.Repositories;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public UnitOfWork(AppDbContext context) => _context = context;
    public async Task CompleteAsync() => await _context.SaveChangesAsync();
}