using E8R.API.Client.Domain.Model.ValueObjects;
using E8R.API.Client.Domain.Model.

namespace E8R.API.Client.Domain.Model.Aggregates;

public class Client
{
    public Client()
    {
        Names = new Names();
        Lastnames = new Lastnames();
        Dni = new Dni();
        Ruc = new Ruc();
        Email = new Email();
        Address = new Address();
    }
    
    public Client(string names, string lastnames, string dni, string ruc, string email, string adress)
    {
        Names = new Names(names);
        Lastnames = new Lastnames(lastnames);
        Dni = new Dni(dni);
        Ruc = new Ruc(ruc);
        Email = new Email(email);
        Address = new Address(adress);
    }
    
    public Client(CreateClientCommand command)
}