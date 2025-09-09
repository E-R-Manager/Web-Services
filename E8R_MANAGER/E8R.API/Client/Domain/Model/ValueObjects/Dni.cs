namespace E8R.API.Client.Domain.Model.ValueObjects;

public record Dni(string CustomerDni)
{
    public Dni() : this(string.Empty)
    {
        
    }
}