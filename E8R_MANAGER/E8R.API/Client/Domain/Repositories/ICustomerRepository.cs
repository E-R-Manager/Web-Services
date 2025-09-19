using E8R.API.Shared.Domain.Repositories;
using E8R.API.Client.Domain.Model.Aggregates;

namespace E8R.API.Client.Domain.Repositories;

public interface ICustomerRepository: IBaseRepository<Customer>
{
    Task<bool> ExistsByNameAsync(string name);
    Task<bool> ExistsByNameAsync(string name, int excludeId);
    Task<bool> ExistsByDniAsync(string dni);
    Task<bool> ExistsByDniAsync(string dni, int excludeId);
    Task<bool> ExistsByRucAsync(string ruc);
    Task<bool> ExistsByRucAsync(string ruc, int excludeId);
    
    Task <IEnumerable<Customer>> FindByNameAsync(string name);
    Task <IEnumerable<Customer>> FindByDniAsync(string dni);
    Task <IEnumerable<Customer>> FindByRucAsync(string ruc);
}