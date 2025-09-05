using E8R.API.Client.Domain.Model.Aggregates;
using E8R.API.Client.Domain.Model.Commands;

namespace E8R.API.Client.Domain.Services;

public interface IClientCommandService
{
    Task<Model.Aggregates.Client?> Handle(CreateClientCommand command);
    Task<Model.Aggregates.Client?> Handle(UpdateClientCommand command);
}