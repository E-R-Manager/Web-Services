using E8R.API.Service.Domain.Model.Aggregates;
using E8R.API.Service.Domain.Model.Queries;

namespace E8R.API.Service.Domain.Services;

public interface IServiceCategoryQueryService
{
    Task<IEnumerable<ServiceCategory>> Handle(GetAllServiceCategoriesQuery query);
    Task<ServiceCategory?> Handle(GetServiceCategoryByIdQuery query);
}