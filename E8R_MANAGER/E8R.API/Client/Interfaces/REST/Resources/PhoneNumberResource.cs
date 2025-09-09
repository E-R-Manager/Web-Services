namespace E8R.API.Client.Interfaces.REST.Resources;

public record PhoneNumberResource(
    int Id,
    string Number,
    int CustomerId
);