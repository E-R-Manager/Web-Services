namespace E8R.API.Client.Domain.Model.ValueObjects;

public record Name(string CustomerName)
{
    public Name() : this(string.Empty)
    {
        
    }
}