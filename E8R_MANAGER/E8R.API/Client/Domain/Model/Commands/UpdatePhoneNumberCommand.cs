namespace E8R.API.Client.Domain.Model.Commands;

public record UpdatePhoneNumberCommand(
    int PhoneNumberId,
    string Number
);