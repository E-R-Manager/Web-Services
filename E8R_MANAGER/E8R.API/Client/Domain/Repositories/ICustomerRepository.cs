using E8R.API.Shared.Domain.Repositories;
using E8R.API.Client.Domain.Model.Aggregates;

namespace E8R.API.Client.Domain.Repositories;

public interface ICustomerRepository: IBaseRepository<Customer>
{
    Task RemoveAsync(Customer customer);
}