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
        // Client Bounded Context
        
        // Client Table
        builder.Entity<Client.Domain.Model.Aggregates.Client>().HasKey(a => a.Id);
        builder.Entity<Client.Domain.Model.Aggregates.Client>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Client.Domain.Model.Aggregates.Client>().Property(a => a.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Client.Domain.Model.Aggregates.Client>().Property(a => a.Dni).IsRequired().HasMaxLength(8);
        builder.Entity<Client.Domain.Model.Aggregates.Client>().Property(a => a.Ruc).IsRequired().HasMaxLength(11);
        builder.Entity<Client.Domain.Model.Aggregates.Client>().Property(a => a.Email).IsRequired().HasMaxLength(100);
        builder.Entity<Client.Domain.Model.Aggregates.Client>().Property(a => a.Address).IsRequired().HasMaxLength(200);
        
        // PhoneNumber Table
        builder.Entity<PhoneNumber>().HasKey(a => a.Id);
        builder.Entity<PhoneNumber>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<PhoneNumber>().Property(a => a.Number).IsRequired().HasMaxLength(9);
        
        // PhoneNumber - Client Relationship
        builder.Entity<PhoneNumber>()
            .HasOne<Client.Domain.Model.Aggregates.Client>()
            .WithMany()
            .HasForeignKey(p => p.Client.Id)
            .IsRequired();

  
        // IAM Bounded Context
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired(); 

        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}