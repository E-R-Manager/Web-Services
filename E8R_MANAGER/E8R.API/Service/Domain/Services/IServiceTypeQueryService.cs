using E8R.API.Service.Domain.Model.Entities;
using E8R.API.Service.Domain.Model.Queries;

namespace E8R.API.Service.Domain.Services;

public interface IServiceTypeQueryService
{
    Task<IEnumerable<ServiceType>> Handle(GetAllServiceTypesQuery query);
    Task<ServiceType?> Handle(GetServiceTypeByIdQuery query);
}