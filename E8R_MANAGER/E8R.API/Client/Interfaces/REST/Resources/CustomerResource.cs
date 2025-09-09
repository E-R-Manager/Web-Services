using E8R.API.Client.Domain.Model.ValueObjects;

namespace E8R.API.Client.Interfaces.REST.Resources;

public record CustomerResource(
    int Id,
    Name Name,
    Dni Dni,
    Ruc Ruc,
    Email Email,
    Address Address,
    CustomerType CustomerType
);