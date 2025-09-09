namespace E8R.API.Client.Domain.Model.ValueObjects;

public record Ruc(string CustomerRuc)
{
    public Ruc() : this(string.Empty)
    {
        
    }
}