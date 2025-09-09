using E8R.API.Client.Domain.Model.ValueObjects;
using E8R.API.Client.Domain.Model.Commands;

namespace E8R.API.Client.Domain.Model.Aggregates;

public class Customer
{
    public Customer()
    {
        Name = string.Empty;
        Dni = string.Empty;
        Ruc = string.Empty;
        Email = string.Empty;
        Address = string.Empty;
        CustomerType = CustomerType.Persona;
    }
    
    public Customer(string name, string dni, string ruc, string email, string address, CustomerType customerType)
    {
        Name = string.Empty;
        Dni = string.Empty;
        Ruc = string.Empty;
        Email = string.Empty;
        Address = string.Empty;
        CustomerType = customerType;
    }
    
    public Customer(CreateCustomerCommand command)
    {
        Name = command.Name;
        Dni = command.Dni;
        Ruc = command.Ruc;
        Email = command.Email;
        Address = command.Address;
        CustomerType = CustomerType.Persona;
    }
    
    public int Id { get; set; }
    public string Name { get; internal set; }
    public string Dni { get; internal set; }
    public string Ruc { get; internal set; }
    public string Email { get; internal set; }
    public string Address { get; internal set; }
    public CustomerType CustomerType { get; internal set; }
}