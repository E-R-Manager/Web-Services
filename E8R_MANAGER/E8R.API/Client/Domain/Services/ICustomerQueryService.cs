using E8R.API.Client.Domain.Model.Aggregates;
using E8R.API.Client.Domain.Model.Queries;

namespace E8R.API.Client.Domain.Services;

public interface ICustomerQueryService
{
    Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery query);
    Task<Customer?> Handle(GetCustomerByIdQuery query);
    Task<IEnumerable<Customer>> Handle(GetCustomersByNameQuery query);
    Task<IEnumerable<Customer>> Handle(GetCustomersByDniQuery query);
    Task<IEnumerable<Customer>> Handle(GetCustomersByRucQuery query);
}