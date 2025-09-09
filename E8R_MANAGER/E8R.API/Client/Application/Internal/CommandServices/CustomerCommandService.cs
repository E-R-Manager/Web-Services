using E8R.API.Client.Domain.Model.Commands;
using E8R.API.Client.Domain.Repositories;
using E8R.API.Client.Domain.Services;
using E8R.API.Shared.Domain.Repositories;
using E8R.API.Client.Domain.Model.Aggregates;
using E8R.API.Client.Domain.Model.ValueObjects;

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
        
        customer.Name = new Name(command.Name);
        customer.Dni = new Dni(command.Dni);
        customer.Ruc = new Ruc(command.Ruc);
        customer.Email = new Email(command.Email);
        customer.Address = new Address(command.Address);
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
        await unitOfWork.CompleteAsync();
        return true;
    }
}