using E8R.API.Client.Domain.Model.Queries;
using E8R.API.Client.Domain.Repositories;
using E8R.API.Client.Domain.Services;

namespace E8R.API.Client.Application.Internal.QueryServices;

public class CustomerQueryService(ICustomerRepository customerRepository) : ICustomerQueryService
{
    public async Task<Domain.Model.Aggregates.Customer?> Handle(GetCustomerByIdQuery query)
    {
        return await customerRepository.FindByIdAsync(query.CustomerId);
    }

    public async Task<IEnumerable<Domain.Model.Aggregates.Customer>> Handle(GetAllCustomersQuery query)
    {
        return await customerRepository.ListAsync();
    }
}