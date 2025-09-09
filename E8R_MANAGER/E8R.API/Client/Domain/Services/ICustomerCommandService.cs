using E8R.API.Client.Domain.Model.Aggregates;
using E8R.API.Client.Domain.Model.Commands;

namespace E8R.API.Client.Domain.Services;

public interface ICustomerCommandService
{
    Task<Customer?> Handle(CreateCustomerCommand command);
    Task<Customer?> Handle(UpdateCustomerCommand command);
    Task<bool> Handle(DeleteCustomerCommand command);
}