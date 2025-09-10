using E8R.API.Service.Domain.Model.Commands;
using E8R.API.Service.Domain.Repositories;
using E8R.API.Service.Domain.Services;
using E8R.API.Shared.Domain.Repositories;
using E8R.API.Service.Domain.Model.Aggregates;

namespace E8R.API.Service.Application.Internal.CommandServices;

public class ServiceCategoryCommandService(
    IServiceCategoryRepository serviceCategoryRepository,
    IUnitOfWork unitOfWork) : IServiceCategoryCommandService
{
    
}