using E8R.API.Client.Domain.Model.ValueObjects;
using E8R.API.Client.Domain.Model.Commands;

namespace E8R.API.Client.Domain.Model.Aggregates;

public class Customer
{
    public Customer()
    {
        Name = new Name();
        Dni = new Dni();
        Ruc = new Ruc();
        Email = new Email();
        Address = new Address();
        CustomerType = CustomerType.Persona;
    }
    
    public Customer(string name, string dni, string ruc, string email, string address, CustomerType customerType)
    {
        Name = new Name(name);
        Dni = new Dni(dni);
        Ruc = new Ruc(ruc);
        Email = new Email(email);
        Address = new Address(address);
        CustomerType = customerType;
    }
    
    public Customer(CreateCustomerCommand command)
    {
        Name = new Name(command.Name);
        Dni = new Dni(command.Dni);
        Ruc = new Ruc(command.Ruc);
        Email = new Email(command.Email);
        Address = new Address(command.Address);
        CustomerType = CustomerType.Persona;
    }
    
    public int Id { get; set; }
    public Name Name { get; internal set; }
    public Dni Dni { get; internal set; }
    public Ruc Ruc { get; internal set; }
    public Email Email { get; internal set; }
    public Address Address { get; internal set; }
    public CustomerType CustomerType { get; internal set; }
}