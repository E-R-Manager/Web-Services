using E8R.API.Client.Domain.Model.Commands;
using E8R.API.Client.Interfaces.REST.Resources;

namespace E8R.API.Client.Interfaces.REST.Transform;

public static class UpdatePhoneNumberCommandFromResourceAssembler
{
    public static UpdatePhoneNumberCommand ToCommandFromResource(UpdatePhoneNumberResource resource, int phoneNumberId)
    {
        return new UpdatePhoneNumberCommand(
            phoneNumberId,
            resource.Number
        );
    }
}
