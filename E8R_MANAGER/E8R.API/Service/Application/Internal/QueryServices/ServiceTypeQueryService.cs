using E8R.API.Service.Domain.Model.Entities;
using E8R.API.Service.Domain.Model.Queries;
using E8R.API.Service.Domain.Repositories;
using E8R.API.Service.Domain.Services;

namespace E8R.API.Service.Application.Internal.QueryServices;

public class ServiceTypeQueryService(IServiceTypeRepository repository) : IServiceTypeQueryService
{
    public async Task<ServiceType?> Handle(GetServiceTypeByIdQuery query)
    {
        return await repository.FindByIdAsync(query.ServiceTypeId);
    }
    public async Task<IEnumerable<ServiceType>> Handle(GetAllServiceTypesQuery query)
    {
        return await repository.ListAsync();
    }
    
}