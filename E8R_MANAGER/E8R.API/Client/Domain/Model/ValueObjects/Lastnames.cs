namespace E8R.API.Client.Domain.Model.ValueObjects;

public record Lastnames(string ClientLastnames)
{
    public Lastnames() : this(string.Empty)
    {
        
    }
}
