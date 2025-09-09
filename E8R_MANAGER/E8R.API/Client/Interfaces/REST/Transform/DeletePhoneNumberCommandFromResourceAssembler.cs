using E8R.API.Client.Domain.Model.Commands;
using E8R.API.Client.Interfaces.REST.Resources;

namespace E8R.API.Client.Interfaces.REST.Transform;

public static class DeletePhoneNumberCommandFromResourceAssembler
{
    public static DeletePhoneNumberCommand ToCommandFromResource(DeletePhoneNumberResource resource)
    {
        return new DeletePhoneNumberCommand(resource.PhoneNumberId);
    }
}
