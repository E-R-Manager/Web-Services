using E8R.API.Client.Domain.Model.Commands;
using E8R.API.Client.Interfaces.REST.Resources;

namespace E8R.API.Client.Interfaces.REST.Transform;

public static class CreateCustomerCommandFromResourceAssembler
{
    public static CreateCustomerCommand ToCommandFromResource(CreateCustomerResource resource)
    {
        return new CreateCustomerCommand(
            resource.Name,
            resource.Dni,
            resource.Ruc,
            resource.Email,
            resource.Address,
            resource.CustomerType
        );
    }
}
