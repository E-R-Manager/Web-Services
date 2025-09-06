using E8R.API.Client.Domain.Model.Commands;
using E8R.API.Client.Domain.Model.Entities;
using E8R.API.Client.Domain.Repositories;
using E8R.API.Client.Domain.Services;
using E8R.API.Shared.Domain.Repositories;

namespace E8R.API.Client.Application.Internal.CommandServices;

public class PhoneNumberCommandService(IPhoneNumberRepository phoneNumberRepository, IUnitOfWork unitOfWork) : IPhoneNumberCommandService
{
    public async Task<PhoneNumber?> Handle(CreatePhoneNumberCommand command)
    {
        var phoneNumber = new PhoneNumber();
        await phoneNumberRepository.AddAsync(phoneNumber);
        await unitOfWork.CompleteAsync();
        return phoneNumber;
    }
}