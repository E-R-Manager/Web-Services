using E8R.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

using E8R.API.Shared.Domain.Repositories;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using E8R.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using E8R.API.Shared.Interfaces.ASP.Configuration;

using E8R.API.Client.Application.Internal.CommandServices;
using E8R.API.Client.Application.Internal.QueryServices;
using E8R.API.Client.Domain.Repositories;
using E8R.API.Client.Domain.Services;
using E8R.API.Client.Infrastructure.Persistence.EFC.Repositories;

using E8R.API.Service.Application.Internal.CommandServices;
using E8R.API.Service.Application.Internal.QueryServices;
using E8R.API.Service.Domain.Repositories;
using E8R.API.Service.Domain.Services;
using E8R.API.Service.Infrastructure.Persistence.EFC.Repositories;

using E8R.API.Inventory.Application.Internal.CommandServices;
using E8R.API.Inventory.Application.Internal.QueryServices;
using E8R.API.Inventory.Domain.Repositories;
using E8R.API.Inventory.Domain.Services;
using E8R.API.Inventory.Infrastructure.Persistence.EFC.Repositories;

using E8R.API.ODS.Application.Internal.CommandServices;
using E8R.API.ODS.Application.Internal.QueryServices;
using E8R.API.ODS.Domain.Repositories;
using E8R.API.ODS.Domain.Services;
using E8R.API.ODS.Infrastructure.Persistence.EFC.Repositories;

using E8R.API.IAM.Application.Internal.CommandServices;
using E8R.API.IAM.Application.Internal.OutboundServices;
using E8R.API.IAM.Application.Internal.QueryServices;
using E8R.API.IAM.Domain.Repositories;
using E8R.API.IAM.Domain.Services;
using E8R.API.IAM.Infrastructure.Hashing.BCrypt.Services;
using E8R.API.IAM.Infrastructure.Persistence.EFC.Repositories;
using E8R.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using E8R.API.IAM.Infrastructure.Tokens.JWT.Configuration;
using E8R.API.IAM.Infrastructure.Tokens.JWT.Services;
using E8R.API.IAM.Interfaces.ACL;
using E8R.API.IAM.Interfaces.ACL.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin() 
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });
    
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",new OpenApiInfo
            {
                Title = "E8R.API",
                Version = "v1.0.0",
                Description = "E&R Manager API",
                TermsOfService = new Uri("https://acme-cargo.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "E&R Servicios informaticos",
                    Email = "<correo>"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            }
        );
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            }
        });
    });
    
// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Client Bounded Context Injection Configuration
// Repository
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// Command
builder.Services.AddScoped<ICustomerCommandService, CustomerCommandService>();

// Query
builder.Services.AddScoped<ICustomerQueryService, CustomerQueryService>();

// Service Bounded Context Injection Configuration
// Repository
builder.Services.AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>();
builder.Services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();

// Command
builder.Services.AddScoped<IServiceCategoryCommandService, ServiceCategoryCommandService>();
builder.Services.AddScoped<IServiceTypeCommandService, ServiceTypeCommandService>();

// Query
builder.Services.AddScoped<IServiceCategoryQueryService, ServiceCategoryQueryService>();
builder.Services.AddScoped<IServiceTypeQueryService, ServiceTypeQueryService>();

// Inventory Bounded Context Injection Configuration
// Repository
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Command
builder.Services.AddScoped<IProductCategoryCommandService, ProductCategoryCommandService>();
builder.Services.AddScoped<IProductTypeCommandService, ProductTypeCommandService>();
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();

// Query
builder.Services.AddScoped<IProductCategoryQueryService, ProductCategoryQueryService>();
builder.Services.AddScoped<IProductTypeQueryService, ProductTypeQueryService>();
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();

// ODS Bounded Context Injection Configuration
// Repository   
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderInventoryRepository, OrderInventoryRepository>();
builder.Services.AddScoped<IOrderServiceRepository, OrderServiceRepository>();

// Command
builder.Services.AddScoped<IOrderCommandService, OrderCommandService>();
builder.Services.AddScoped<IOrderInventoryCommandService, OrderInventoryCommandService>();
builder.Services.AddScoped<IOrderServiceCommandService, OrderServiceCommandService>();

// Query
builder.Services.AddScoped<IOrderQueryService, OrderQueryService>();
builder.Services.AddScoped<IOrderInventoryQueryService, OrderInventoryQueryService>();
builder.Services.AddScoped<IOrderServiceQueryService, OrderServiceQueryService>();

// TokenSettings Configuration
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();


var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
// Add Authorization Middleware to Pipeline
app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();