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
        // Validaciones de unicidad
        if (await customerRepository.ExistsByNameAsync(command.Name))
            throw new InvalidOperationException("El nombre de cliente ya existe.");
        if (await customerRepository.ExistsByDniAsync(command.Dni))
            throw new InvalidOperationException("El DNI ya existe.");
        if (!string.IsNullOrEmpty(command.Ruc) && await customerRepository.ExistsByRucAsync(command.Ruc))
            throw new InvalidOperationException("El RUC ya existe.");

        // Validación de CustomerType y RUC
        if (command.CustomerType == CustomerType.Empresa && string.IsNullOrWhiteSpace(command.Ruc))
            throw new InvalidOperationException("El RUC es obligatorio para CustomerType 1.");

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
        
        if (await customerRepository.ExistsByNameAsync(command.Name, command.CustomerId))
            throw new InvalidOperationException("El nombre de cliente ya existe.");
        if (await customerRepository.ExistsByDniAsync(command.Dni, command.CustomerId))
            throw new InvalidOperationException("El DNI ya existe.");
        if (!string.IsNullOrEmpty(command.Ruc) && await customerRepository.ExistsByRucAsync(command.Ruc, command.CustomerId))
            throw new InvalidOperationException("El RUC ya existe.");
        
        if (command.CustomerType == CustomerType.Empresa && string.IsNullOrWhiteSpace(command.Ruc))
            throw new InvalidOperationException("El RUC es obligatorio para CustomerType 1.");
        
        customer.Name = command.Name;
        customer.Dni = command.Dni;
        customer.Ruc = command.Ruc;
        customer.Email = command.Email;
        customer.Address = command.Address;
        customer.CustomerType = command.CustomerType;
        
        await unitOfWork.CompleteAsync();
        return customer;
    }
}