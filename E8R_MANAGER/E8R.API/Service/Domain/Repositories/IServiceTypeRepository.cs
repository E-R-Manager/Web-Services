using E8R.API.Shared.Domain.Repositories;
using E8R.API.Client.Domain.Model.Entities;
using E8R.API.Service.Domain.Model.Entities;

namespace E8R.API.Service.Domain.Repositories;

public interface IServiceTypeRepository : IBaseRepository<ServiceType>
{
    Task RemoveAsync(ServiceType serviceType);
    Task <IEnumerable<ServiceType>> FindByServiceCategoryIdAsync(int serviceCategoryId);
}