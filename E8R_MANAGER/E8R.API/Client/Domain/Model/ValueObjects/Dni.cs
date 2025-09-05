namespace E8R.API.Client.Domain.Model.ValueObjects;

public record Dni(string ClientDni)
{
    public Dni() : this(string.Empty)
    {
        
    }
}