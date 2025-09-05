using E8R.API.Shared.Domain.Repositories;
using E8R.API.Client.Domain.Model.Entities;

namespace E8R.API.Client.Domain.Repositories;

public interface IPhoneNumberRepository : IBaseRepository<PhoneNumber>
{
    Task<IEnumerable<PhoneNumber>> FindByClientIdAsync(int clientId);
}