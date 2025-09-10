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
    public async Task<ServiceCategory?> Handle(CreateServiceCategoryCommand command)
    {
        var serviceCategory = new ServiceCategory(command);
        await serviceCategoryRepository.AddAsync(serviceCategory);
        await unitOfWork.CompleteAsync();
        return serviceCategory;
    }

    public async Task<ServiceCategory?> Handle(UpdateServiceCategoryCommand command)
    {
        var serviceCategory = await serviceCategoryRepository.FindByIdAsync(command.ServiceCategoryId);
        if (serviceCategory == null)
        {
            return null;
        }
        serviceCategory.Name = command.Name;
        serviceCategory.ContractedAmount = command.ContractedAmount;
        await unitOfWork.CompleteAsync();
        return serviceCategory;
    }
    
    public async Task<bool> Handle(DeleteServiceCategoryCommand command)
    {
        var serviceCategory = await serviceCategoryRepository.FindByIdAsync(command.ServiceCategoryId);
        if (serviceCategory == null)
        {
            return false;
        }
        serviceCategoryRepository.Remove(serviceCategory);
        await unitOfWork.CompleteAsync();
        return true;
    }
}