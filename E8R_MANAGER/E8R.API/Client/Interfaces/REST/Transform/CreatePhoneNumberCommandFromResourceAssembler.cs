using E8R.API.Client.Domain.Model.Commands;
using E8R.API.Client.Interfaces.REST.Resources;


namespace E8R.API.Client.Interfaces.REST.Transform;

public static class CreatePhoneNumberCommandFromResourceAssembler
{
    public static CreatePhoneNumberCommand ToCommandFromResource(CreatePhoneNumberResource resource)
    {
        return new CreatePhoneNumberCommand(
            resource.Number,
            resource.CustomerId
        );
    }
}
