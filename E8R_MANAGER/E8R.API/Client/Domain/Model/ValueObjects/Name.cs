namespace E8R.API.Client.Domain.Model.ValueObjects;

public record Name(string ClientName)
{
    public Name() : this(string.Empty)
    {
        
    }
}