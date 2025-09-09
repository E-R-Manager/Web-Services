namespace E8R.API.Client.Domain.Model.Commands;

public record CreatePhoneNumberCommand(
    string Number,
    int CustomerId
);