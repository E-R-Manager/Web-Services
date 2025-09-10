using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using E8R.API.IAM.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using E8R.API.Client.Domain.Model.Aggregates;
using E8R.API.Client.Domain.Model.Entities;

using E8R.API.Service.Domain.Model.Aggregates;
using E8R.API.Service.Domain.Model.Entities;

using E8R.API.Inventory.Domain.Model.Aggregates;
using E8R.API.Inventory.Domain.Model.Entities;

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
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

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
        
        // Inventory Bounded Context
        // ProductCategory Table
        builder.Entity<ProductCategory>().HasKey(pc => pc.Id);
        builder.Entity<ProductCategory>().Property(pc => pc.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ProductCategory>().Property(pc => pc.Name).IsRequired().HasMaxLength(100);
        
        // ProductType Table
        builder.Entity<ProductType>().HasKey(pt => pt.Id);
        builder.Entity<ProductType>().Property(pt => pt.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ProductType>().Property(pt => pt.Name).IsRequired().HasMaxLength(100);
        
        // Product Table
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Product>().Property(p => p.Price).IsRequired();
        builder.Entity<Product>().Property(p => p.Stock).IsRequired();
        builder.Entity<Product>().Property(p => p.QuantitySold).IsRequired();
        
        // Product - ProductType Relationship
        builder.Entity<Product>()
            .HasOne(p => p.ProductType)
            .WithMany()
            .HasForeignKey(p => p.ProductTypeId);
        
        // ProductType - ProductCategory Relationship
        builder.Entity<ProductType>()
            .HasOne(pt => pt.ProductCategory)
            .WithMany()
            .HasForeignKey(pt => pt.ProductCategoryId)
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