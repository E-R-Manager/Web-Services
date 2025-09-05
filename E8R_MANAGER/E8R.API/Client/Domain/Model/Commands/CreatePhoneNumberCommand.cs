using E8R.API.Client.Domain.Model.Aggregates;

namespace E8R.API.Client.Domain.Model.Commands;

public record CreatePhoneNumberCommand(
    string Number,
    Aggregates.Client Client
);