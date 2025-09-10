using E8R.API.Service.Domain.Model.Aggregates;
using E8R.API.Service.Domain.Model.Commands;

namespace E8R.API.Service.Domain.Services;

public interface IServiceCategoryCommandService
{
    Task<ServiceCategory?> Handle(CreateServiceCategoryCommand command);
    Task<ServiceCategory?> Handle(UpdateServiceCategoryCommand command);
    Task<bool> Handle(DeleteServiceCategoryCommand command);
}