using E8R.API.Service.Domain.Model.Entities;
using E8R.API.Service.Domain.Model.Commands;

namespace E8R.API.Service.Domain.Services;

public interface IServiceTypeCommandService
{
    Task<ServiceType?> Handle(CreateServiceTypeCommand command);
    Task<ServiceType?> Handle(UpdateServiceTypeCommand command);
    Task<bool> Handle(DeleteServiceTypeCommand command);
}