namespace E8R.API.ODS.Domain.Model.Queries;

public record GetOrdersByOrderDateQuery(int Year, int? Month, int? Day);