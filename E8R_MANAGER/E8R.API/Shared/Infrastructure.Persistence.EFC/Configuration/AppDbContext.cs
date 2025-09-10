using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using E8R.API.IAM.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using E8R.API.Client.Domain.Model.Aggregates;
using E8R.API.Client.Domain.Model.Entities;

using E8R.API.Service.Domain.Model.Aggregates;
using E8R.API.Service.Domain.Model.Entities;

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
    public DbSet<Customer> Customers { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    public DbSet<ServiceCategory> ServiceCategories { get; set; }
    public DbSet<ServiceType> ServiceTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Client Bounded Context
        // Customer Table
        builder.Entity<Customer>().HasKey(a => a.Id);
        builder.Entity<Customer>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Customer>().Property(a => a.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Customer>().Property(a => a.Dni).IsRequired().HasMaxLength(8);
        builder.Entity<Customer>().Property(a => a.Ruc).IsRequired().HasMaxLength(11);
        builder.Entity<Customer>().Property(a => a.Email).IsRequired().HasMaxLength(100);
        builder.Entity<Customer>().Property(a => a.Address).IsRequired().HasMaxLength(200);
        builder.Entity<Customer>().Property(a => a.CustomerType).IsRequired();
        
        // PhoneNumber Table
        builder.Entity<PhoneNumber>().HasKey(a => a.Id);
        builder.Entity<PhoneNumber>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<PhoneNumber>().Property(a => a.Number).IsRequired().HasMaxLength(9);
        
        // PhoneNumber - Customer Relationship
        builder.Entity<PhoneNumber>()
            .HasOne(p => p.Customer)
            .WithMany()
            .HasForeignKey(p => p.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Service Bounded Context
        // ServiceCategory Table
        builder.Entity<ServiceCategory>().HasKey(sc => sc.Id);
        builder.Entity<ServiceCategory>().Property(sc => sc.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ServiceCategory>().Property(sc => sc.Name).IsRequired().HasMaxLength(100);
        builder.Entity<ServiceCategory>().Property(sc => sc.ContractedAmount).IsRequired();
        
        // ServiceType Table
        builder.Entity<ServiceType>().HasKey(st => st.Id);
        builder.Entity<ServiceType>().Property(st => st.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ServiceType>().Property(st => st.Name).IsRequired().HasMaxLength(100);
        
        // ServiceType - ServiceCategory Relationship
        builder.Entity<ServiceType>()
            .HasOne(st => st.ServiceCategory)
            .WithMany()
            .HasForeignKey(st => st.ServiceCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // IAM Bounded Context
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired(); 

        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}