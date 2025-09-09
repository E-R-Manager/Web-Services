namespace E8R.API.Client.Domain.Model.ValueObjects;

public record Email(string CustomerEmail)
{
    public Email() : this(string.Empty)
    {
        
    }
}