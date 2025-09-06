using E8R.API.Client.Domain.Model.Entities;
using E8R.API.Client.Domain.Model.Queries;
using E8R.API.Client.Domain.Repositories;
using E8R.API.Client.Domain.Services;

namespace E8R.API.Client.Application.Internal.QueryServices;

public class ClientQueryService(IClientRepository clientRepository, IPhoneNumberRepository phoneNumberRepository) : IClientQueryService
{
    public async Task<Domain.Model.Aggregates.Client?> Handle(GetClientByIdQuery query)
    {
        return await clientRepository.FindByIdAsync(query.ClientId);
    }

    public async Task<IEnumerable<Domain.Model.Aggregates.Client>> Handle(GetAllClientsQuery query)
    {
        return await clientRepository.ListAsync();
    }

    public async Task<IEnumerable<PhoneNumber>> Handle(GetPhoneNumbersByClientIdQuery query)
    {
        return await phoneNumberRepository.FindByClientIdAsync(query.ClientId);
    }
}