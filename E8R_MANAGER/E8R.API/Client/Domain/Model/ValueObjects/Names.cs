namespace E8R.API.Client.Domain.Model.ValueObjects;

public record Names(string ClientNames)
{
    public Names() : this(string.Empty)
    {
        
    }
}