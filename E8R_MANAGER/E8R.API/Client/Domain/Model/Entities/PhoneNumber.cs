using E8R.API.Client.Domain.Model.Aggregates;

namespace E8R.API.Client.Domain.Model.Entities;

public class PhoneNumber
{
    public PhoneNumber()
    {
        Number = string.Empty;
        Client = new Aggregates.Client();
    }

    public PhoneNumber(string number, Aggregates.Client client)
    {
        Number = number;
        Client = client;
    }
    
    public int Id { get; set; }
    public string Number { get; internal set; }
    public Aggregates.Client Client { get; internal set; }
}