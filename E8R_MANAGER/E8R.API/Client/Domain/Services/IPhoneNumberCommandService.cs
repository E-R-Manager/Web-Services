using E8R.API.Client.Domain.Model.Entities;
using E8R.API.Client.Domain.Model.Commands;

namespace E8R.API.Client.Domain.Services;

public interface IPhoneNumberCommandService
{
    Task<PhoneNumber?> Handle(CreatePhoneNumberCommand command);
    Task<PhoneNumber?> Handle(UpdatePhoneNumberCommand command);
}