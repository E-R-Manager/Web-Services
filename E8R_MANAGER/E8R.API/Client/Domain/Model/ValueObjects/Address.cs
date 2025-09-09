namespace E8R.API.Client.Domain.Model.ValueObjects;

public record Address(string CustomerAddress)
{
    public Address() : this(string.Empty)
    {
        
    }
}