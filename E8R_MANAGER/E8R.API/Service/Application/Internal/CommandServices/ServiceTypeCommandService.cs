using E8R.API.Service.Domain.Model.Commands;
using E8R.API.Service.Domain.Repositories;
using E8R.API.Service.Domain.Services;
using E8R.API.Shared.Domain.Repositories;
using E8R.API.Service.Domain.Model.Entities;
using E8R.API.Service.Domain.Model.Aggregates;

namespace E8R.API.Service.Application.Internal.CommandServices;

public class ServiceTypeCommandService(
    IServiceTypeRepository serviceTypeRepository,
    IUnitOfWork unitOfWork,
    IServiceCategoryRepository serviceCategoryRepository) : IServiceTypeCommandService
{
    public async Task<ServiceType?> Handle(CreateServiceTypeCommand command)
    {
        var serviceCategory = await serviceCategoryRepository.FindByIdAsync(command.ServiceCategoryId);
        if (serviceCategory == null)
        {
            throw new ArgumentException("Service Category Id no encontrado.");
        }
        var serviceType = new ServiceType(command, serviceCategory);
        await serviceTypeRepository.AddAsync(serviceType);
        await unitOfWork.CompleteAsync();
        return serviceType;
    }

    public async Task<ServiceType?> Handle(UpdateServiceTypeCommand command)
    {
        var serviceType = await serviceTypeRepository.FindByIdAsync(command.ServiceTypeId);
        if (serviceType == null)
        {
            return null;
        }
        serviceType.Name = command.Name;
        await unitOfWork.CompleteAsync();
        return serviceType;
    }
    
    public async Task<bool> Handle(DeleteServiceTypeCommand command)
    {
        var serviceType = await serviceTypeRepository.FindByIdAsync(command.ServiceTypeId);
        if (serviceType == null)
        {
            return false;
        }
        serviceTypeRepository.Remove(serviceType);
        await unitOfWork.CompleteAsync();
        return true;
    }
}
