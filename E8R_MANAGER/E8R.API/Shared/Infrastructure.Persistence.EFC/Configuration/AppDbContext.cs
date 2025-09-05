using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using E8R.API.IAM.Domain.Model.Aggregates;

using E8R.API.Client.Domain.Model.Aggregates;
using E8R.API.Client.Domain.Model.Entities;

namespace E8R.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{ 
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Client.Domain.Model.Aggregates.Client> Clients { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Client Table
        
        // PhoneNumber Table
        builder.Entity<PhoneNumber>().HasKey(a => a.Id);
        
        
        // IAM Bounded Context
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired(); 

        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}