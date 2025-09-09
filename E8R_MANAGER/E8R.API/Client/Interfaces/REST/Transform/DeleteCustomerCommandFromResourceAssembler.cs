using E8R.API.Client.Domain.Model.Commands;
using E8R.API.Client.Interfaces.REST.Resources;

namespace E8R.API.Client.Interfaces.REST.Transform;

public static class DeleteCustomerCommandFromResourceAssembler
{
    public static DeleteCustomerCommand ToCommandFromResource(DeleteCustomerResource resource)
    {
        return new DeleteCustomerCommand(resource.CustomerId);
    }
}
