using E8R.API.ODS.Domain.Model.ValueObjects;
namespace E8R.API.ODS.Domain.Model.Queries;

public record GetOrdersByOrderStateQuery(OrderState OrderState);