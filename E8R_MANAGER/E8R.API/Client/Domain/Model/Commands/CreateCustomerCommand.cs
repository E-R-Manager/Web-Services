using E8R.API.Client.Domain.Model.ValueObjects;

namespace E8R.API.Client.Domain.Model.Commands;

public record CreateCustomerCommand(
    string Name, 
    string Dni, 
    string Ruc, 
    string Email, 
    string Address, 
    CustomerType CustomerType
);