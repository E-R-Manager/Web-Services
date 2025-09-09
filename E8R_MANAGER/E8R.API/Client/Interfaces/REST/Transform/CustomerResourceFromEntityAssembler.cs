using E8R.API.Client.Interfaces.REST.Resources;
using E8R.API.Client.Domain.Model.Aggregates;

namespace E8R.API.Client.Interfaces.REST.Transform;

public static class CustomerResourceFromEntityAssembler
{
    public static CustomerResource ToResourceFromEntity(Customer entity)
    {
        return new CustomerResource(
            entity.Id,
            entity.Name,
            entity.Dni,
            entity.Ruc,
            entity.Email,
            entity.Address,
            entity.CustomerType
        );
    }
}
