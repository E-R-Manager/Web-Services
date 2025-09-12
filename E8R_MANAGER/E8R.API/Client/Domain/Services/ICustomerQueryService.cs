using E8R.API.Client.Domain.Model.Aggregates;
using E8R.API.Client.Domain.Model.Queries;

namespace E8R.API.Client.Domain.Services;

public interface ICustomerQueryService
{
    Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery query);
    Task<Customer?> Handle(GetCustomerByIdQuery query);
}