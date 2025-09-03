namespace E8R.API.Shared.Infrastructure.Persistence.EFC.Configuration;

using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}