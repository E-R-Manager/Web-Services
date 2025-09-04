using E8R.API.IAM.Interfaces.REST.Resources;

namespace E8R.API.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(Domain.Model.Aggregates.User user)
    {
        return new UserResource(user.Id, user.Username);
    }
}