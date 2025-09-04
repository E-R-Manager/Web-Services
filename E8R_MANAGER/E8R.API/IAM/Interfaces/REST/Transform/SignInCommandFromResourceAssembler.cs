using E8R.API.IAM.Domain.Model.Commands;
using E8R.API.IAM.Interfaces.REST.Resources;

namespace E8R.API.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}