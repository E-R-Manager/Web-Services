using E8R.API.IAM.Domain.Model.Commands;
using E8R.API.IAM.Interfaces.REST.Resources;

namespace E8R.API.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }
}