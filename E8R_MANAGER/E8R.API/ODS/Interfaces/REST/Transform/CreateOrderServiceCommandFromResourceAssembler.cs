using E8R.API.ODS.Domain.Model.Commands;
using E8R.API.ODS.Interfaces.REST.Resources;

namespace E8R.API.ODS.Interfaces.REST.Transform;

public static class CreateOrderServiceCommandFromResourceAssembler
{
    public static CreateOrderServiceCommand ToCommandFromResource(CreateOrderServiceResourceAh resource)
    {
        return new CreateOrderServiceCommand(
            resource.OrderId,
            resource.ServiceId,
            resource.ServiceCategoryName,
            resource.ServiceTypeName,
            resource.Details,
            resource.Price
        );
    }
}