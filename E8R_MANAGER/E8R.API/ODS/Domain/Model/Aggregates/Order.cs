using E8R.API.Client.Domain.Model.Aggregates;
using E8R.API.ODS.Domain.Model.Commands;
using E8R.API.ODS.Domain.Model.ValueObjects;

namespace E8R.API.ODS.Domain.Model.Aggregates;

public class Order
{
    public Order()
    {
        Customer = new Customer();
        CustomerName = string.Empty;
        CustomerDni = string.Empty;
        CustomerPhoneNumber = string.Empty;
        CustomerAddress = string.Empty;
        OrderDate = DateOnly.FromDateTime(DateTime.UtcNow);
        OrderState = OrderState.Proforma;
    }

    public Order(Customer customer, int customerId, string customerName, string customerDni, string customerPhoneNumber, string customerAddress, DateOnly orderDate, OrderState orderState)
    {
        Customer = customer;
        CustomerId = customerId;
        CustomerName = customerName;
        CustomerDni = customerDni;
        CustomerPhoneNumber = customerPhoneNumber;
        CustomerAddress = customerAddress;
        OrderDate = orderDate;
        OrderState = orderState;
    }

    public Order(CreateOrderCommand command, Customer customer)
    {
        Customer = customer;
        CustomerId = customer.Id;
        CustomerName = customer.Name;
        CustomerDni = customer.Dni;
        CustomerPhoneNumber = customer.PhoneNumber;
        CustomerAddress = customer.Address;
        OrderDate = command.OrderDate;
        OrderState = command.OrderState;
    }
    
    public int Id { get; set; }
    public Customer Customer { get; internal set; }
    public int CustomerId { get; internal set; }
    public string CustomerName { get; internal set; }
    public string CustomerDni { get; internal set; }
    public string CustomerPhoneNumber { get; internal set; }
    public string CustomerAddress { get; internal set; }
    public DateOnly OrderDate { get; internal set; }
    public OrderState OrderState { get; internal set; }
}