using E8R.API.Client.Domain.Model.ValueObjects;

namespace E8R.API.Client.Interfaces.REST.Resources;

public record CustomerResource(
    int Id,
    string Name,
    string Dni,
    string Ruc,
    string PhoneNumber,
    string Email,
    string Address,
    CustomerType CustomerType
);