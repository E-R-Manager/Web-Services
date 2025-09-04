using E8R.API.IAM.Interfaces.REST.Resources;

namespace E8R.API.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        Domain.Model.Aggregates.User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, token);
    }
}