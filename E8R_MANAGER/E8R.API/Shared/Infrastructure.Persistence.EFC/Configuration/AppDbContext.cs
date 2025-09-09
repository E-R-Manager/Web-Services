using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using E8R.API.IAM.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using E8R.API.Client.Domain.Model.Aggregates;
using E8R.API.Client.Domain.Model.Entities;
using E8R.API.Client.Domain.Model.ValueObjects;

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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customer Bounded Context
        
        // Customer Table
        var nameConverter = new ValueConverter<Name, string>(
            v => v.CustomerName,
            v => new Name(v)
        );
        var dniConverter = new ValueConverter<Dni, string>(
            v => v.CustomerDni,
            v => new Dni(v)
        );
        var rucConverter = new ValueConverter<Ruc, string>(
            v => v.CustomerRuc,
            v => new Ruc(v)
        );
        var emailConverter = new ValueConverter<Email, string>(
            v => v.CustomerEmail,
            v => new Email(v)
        );
        var addressConverter = new ValueConverter<Address, string>(
            v => v.CustomerAddress,
            v => new Address(v)
        );
        
        builder.Entity<Customer>().HasKey(a => a.Id);
        builder.Entity<Customer>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Customer>().Property(a => a.Name).HasConversion(nameConverter).IsRequired().HasMaxLength(100);
        builder.Entity<Customer>().Property(a => a.Dni).HasConversion(dniConverter).IsRequired().HasMaxLength(8);
        builder.Entity<Customer>().Property(a => a.Ruc).HasConversion(rucConverter).IsRequired().HasMaxLength(11);
        builder.Entity<Customer>().Property(a => a.Email).HasConversion(emailConverter).IsRequired().HasMaxLength(100);
        builder.Entity<Customer>().Property(a => a.Address).HasConversion(addressConverter).IsRequired().HasMaxLength(200);
        builder.Entity<Customer>().Property(a => a.CustomerType).IsRequired();
        
        // PhoneNumber Table
        builder.Entity<PhoneNumber>().HasKey(a => a.Id);
        builder.Entity<PhoneNumber>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<PhoneNumber>().Property(a => a.Number).IsRequired().HasMaxLength(9);
        
        // PhoneNumber - Customer Relationship
        builder.Entity<PhoneNumber>()
            .HasOne<Customer>()
            .WithMany()
            .HasForeignKey(p => p.CustomerId)
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