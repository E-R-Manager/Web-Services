using E8R.API.Client.Domain.Model.Commands;
using E8R.API.Client.Domain.Model.Entities;
using E8R.API.Client.Domain.Repositories;
using E8R.API.Client.Domain.Services;
using E8R.API.Shared.Domain.Repositories;

namespace E8R.API.Client.Application.Internal.CommandServices;

public class PhoneNumberCommandService(IPhoneNumberRepository phoneNumberRepository, ICustomerRepository customerRepository ,IUnitOfWork unitOfWork) : IPhoneNumberCommandService
{
    public async Task<PhoneNumber?> Handle(CreatePhoneNumberCommand command)
    {
        var customer = await customerRepository.FindByIdAsync(command.CustomerId);
        if (customer == null)
        {
            throw new ArgumentException("Customer Id no encontrado.");
        }
        var phoneNumber = new PhoneNumber(command, customer);
        await phoneNumberRepository.AddAsync(phoneNumber);
        await unitOfWork.CompleteAsync();
        return phoneNumber;
    }
    
    public async Task<PhoneNumber?> Handle(UpdatePhoneNumberCommand command)
    {
        var phoneNumber = await phoneNumberRepository.FindByIdAsync(command.PhoneNumberId);
        if (phoneNumber == null)
        {
            return null;
        }
        
        // Update the Phone Number Information
        phoneNumber.Number = command.Number;
        
        await unitOfWork.CompleteAsync();
        return phoneNumber;
    }

    public async Task<bool> Handle(DeletePhoneNumberCommand command)
    {
        var phoneNumber = await phoneNumberRepository.FindByIdAsync(command.PhoneNumberId);
        if (phoneNumber == null)
        {
            return false;
        }

        await phoneNumberRepository.RemoveAsync(phoneNumber);
        await unitOfWork.CompleteAsync();
        return true;
    }
}