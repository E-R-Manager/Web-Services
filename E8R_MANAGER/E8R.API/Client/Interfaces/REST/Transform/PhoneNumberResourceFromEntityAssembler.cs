using E8R.API.Client.Domain.Model.Entities;
using E8R.API.Client.Interfaces.REST.Resources;

namespace E8R.API.Client.Interfaces.REST.Transform;

public static class PhoneNumberResourceFromEntityAssembler
{
    public static PhoneNumberResource ToResourceFromEntity(PhoneNumber entity)
    {
        return new PhoneNumberResource(
            entity.Id,
            entity.Number,
            entity.CustomerId
        );
    }
}
