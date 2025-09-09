using E8R.API.Client.Domain.Model.Commands;
using E8R.API.Client.Interfaces.REST.Resources;

namespace E8R.API.Client.Interfaces.REST.Transform;

public static class UpdateCustomerCommandFromResourceAssembler
{
    public static UpdateCustomerCommand ToCommandFromResource(UpdateCustomerResource resource, int customerId)
    {
        return new UpdateCustomerCommand(
            customerId,
            resource.Name,
            resource.Dni,
            resource.Ruc,
            resource.Email,
            resource.Address,
            resource.CustomerType
        );
    }
}
