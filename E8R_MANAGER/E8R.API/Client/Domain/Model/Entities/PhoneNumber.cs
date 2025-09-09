using E8R.API.Client.Domain.Model.Aggregates;
using E8R.API.Client.Domain.Model.Commands;

namespace E8R.API.Client.Domain.Model.Entities;

public class PhoneNumber
{
    public PhoneNumber()
    {
        Number = string.Empty;
        Customer = new Customer();
    }

    public PhoneNumber(string number, Customer customer, int customerId)
    {
        Number = number;
        Customer = customer;
        CustomerId = customerId;
    }
    
    public PhoneNumber(CreatePhoneNumberCommand command, Customer customer)
    {
        Number = command.Number;
        Customer = customer;
        CustomerId = customer.Id;
    }
    
    public int Id { get; set; }
    public string Number { get; internal set; }
    public Customer Customer { get; internal set; }
    public int CustomerId { get; internal set; }
}