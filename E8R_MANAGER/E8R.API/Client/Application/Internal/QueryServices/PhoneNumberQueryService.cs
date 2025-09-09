using E8R.API.Client.Domain.Model.Entities;
using E8R.API.Client.Domain.Model.Queries;
using E8R.API.Client.Domain.Repositories;
using E8R.API.Client.Domain.Services;

namespace E8R.API.Client.Application.Internal.QueryServices;

public class PhoneNumberQueryService(IPhoneNumberRepository phoneNumberRepository) : IPhoneNumberQueryService
{
    public async Task<PhoneNumber?> Handle(GetPhoneNumberByIdQuery query)
    {
        return await phoneNumberRepository.FindByIdAsync(query.PhoneNumberId);
    }

    public async Task<IEnumerable<PhoneNumber>> Handle(GetAllPhoneNumbersQuery query)
    {
        return await phoneNumberRepository.ListAsync();
    }
    
    public async Task<IEnumerable<PhoneNumber>> Handle(GetPhoneNumbersByCustomerIdQuery query)
    {
        return await phoneNumberRepository.FindByCustomerIdAsync(query.CustomerId);
    }
}