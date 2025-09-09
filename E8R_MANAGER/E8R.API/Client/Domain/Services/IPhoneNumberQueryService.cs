using E8R.API.Client.Domain.Model.Entities;
using E8R.API.Client.Domain.Model.Queries;

namespace E8R.API.Client.Domain.Services;

public interface IPhoneNumberQueryService
{
    Task<IEnumerable<PhoneNumber>> Handle(GetAllPhoneNumbersQuery query);
    Task<PhoneNumber?> Handle(GetPhoneNumberByIdQuery query);
    Task<IEnumerable<PhoneNumber>> Handle(GetPhoneNumbersByCustomerIdQuery query);
}