using E8R.API.Client.Domain.Model.Commands;
using E8R.API.Client.Domain.Repositories;
using E8R.API.Client.Domain.Services;
using E8R.API.Shared.Domain.Repositories;
using E8R.API.Client.Domain.Model.Aggregates;

namespace E8R.API.Client.Application.Internal.CommandServices;

public class CustomerCommandService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    : ICustomerCommandService
{
    public async Task<Customer?> Handle(CreateCustomerCommand command)
    {
        var customer = new Customer(command);
        await customerRepository.AddAsync(customer);
        await unitOfWork.CompleteAsync();
        return customer;
    }

    public async Task<Customer?> Handle(UpdateCustomerCommand command)
    {
        var customer = await customerRepository.FindByIdAsync(command.CustomerId);
        if (customer == null)
        {
            return null;
        }
        
        customer.Name = command.Name;
        customer.Dni = command.Dni;
        customer.Ruc = command.Ruc;
        customer.Email = command.Email;
        customer.Address = command.Address;
        customer.CustomerType = command.CustomerType;
        
        await unitOfWork.CompleteAsync();
        return customer;
    }

    public async Task<bool> Handle(DeleteCustomerCommand command)
    {
        var customer = await customerRepository.FindByIdAsync(command.CustomerId);
        if (customer == null)
        {
            return false;
        }
        await customerRepository.RemoveAsync(customer);
        await unitOfWork.CompleteAsync();
        return true;
    }
}