using E8R.API.Client.Domain.Model.Queries;
using E8R.API.Client.Domain.Model.Aggregates;
using E8R.API.Client.Domain.Repositories;
using E8R.API.Client.Domain.Services;

namespace E8R.API.Client.Application.Internal.QueryServices;

public class CustomerQueryService(ICustomerRepository customerRepository) : ICustomerQueryService
{
    public async Task<Customer?> Handle(GetCustomerByIdQuery query)
    {
        return await customerRepository.FindByIdAsync(query.CustomerId);
    }

    public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery query)
    {
        return await customerRepository.ListAsync();
    }
    
    public async Task<IEnumerable<Customer>> Handle(GetCustomersByNameQuery query)
    {
        return await customerRepository.FindByNameAsync(query.Name);
    }
    
    public async Task<IEnumerable<Customer>> Handle(GetCustomersByDniQuery query)
    {
        return await customerRepository.FindByDniAsync(query.Dni);
    }
    
    public async Task<IEnumerable<Customer>> Handle(GetCustomersByRucQuery query)
    {
        return await customerRepository.FindByRucAsync(query.Ruc);
    }
    
    public async Task<(IEnumerable<Customer> Customers, int TotalCount)> Handle(GetAllCustomersPaginationQuery query)
    {
        return await customerRepository.GetAllCustomersPaginationQueryAsync(query.Page, query.PageSize);
    }
    
}