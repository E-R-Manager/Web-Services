using E8R.API.Client.Domain.Model.Aggregates;
using E8R.API.Client.Domain.Model.Entities;
using E8R.API.Client.Domain.Model.Queries;

namespace E8R.API.Client.Domain.Services;

public interface IClientQueryService
{
    Task<IEnumerable<Model.Aggregates.Client>> Handle(GetAllClientsQuery query);
    Task<Model.Aggregates.Client?> Handle(GetClientByIdQuery query);
    Task<IEnumerable<PhoneNumber>> Handle(GetPhoneNumbersByClientIdQuery query);
}