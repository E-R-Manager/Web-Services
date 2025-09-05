namespace E8R.API.Client.Domain.Model.ValueObjects;

public record Email(string ClientEmail)
{
    public Email() : this(string.Empty)
    {
        
    }
}