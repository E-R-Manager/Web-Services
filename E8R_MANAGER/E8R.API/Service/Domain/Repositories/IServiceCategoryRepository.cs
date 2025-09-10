using E8R.API.Shared.Domain.Repositories;
using E8R.API.Service.Domain.Model.Aggregates;

namespace E8R.API.Service.Domain.Repositories;

public interface IServiceCategoryRepository : IBaseRepository<ServiceCategory>
{
    Task RemoveAsync(ServiceCategory serviceCategory);
}