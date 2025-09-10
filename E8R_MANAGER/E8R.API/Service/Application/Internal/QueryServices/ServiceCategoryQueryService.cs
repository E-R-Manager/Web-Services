using E8R.API.Service.Domain.Model.Aggregates;
using E8R.API.Service.Domain.Model.Queries;
using E8R.API.Service.Domain.Repositories;
using E8R.API.Service.Domain.Services;

namespace E8R.API.Service.Application.Internal.QueryServices;

public class ServiceCategoryQueryService(IServiceCategoryRepository serviceCategoryRepository) 
    : IServiceCategoryQueryService
{
    public async Task<ServiceCategory?> Handle(GetServiceCategoryByIdQuery query)
    {
        return await serviceCategoryRepository.FindByIdAsync(query.ServiceCategoryId);
    }
    
    public async Task<IEnumerable<ServiceCategory>> Handle(GetAllServiceCategoriesQuery query)
    {
        return await serviceCategoryRepository.ListAsync();
    }
}