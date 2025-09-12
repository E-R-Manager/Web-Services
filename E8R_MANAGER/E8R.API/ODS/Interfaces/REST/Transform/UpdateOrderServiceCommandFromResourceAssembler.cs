using E8R.API.ODS.Domain.Model.Commands;
using E8R.API.ODS.Interfaces.REST.Resources;

namespace E8R.API.ODS.Interfaces.REST.Transform;

public static class UpdateOrderServiceCommandFromResourceAssembler
{
    public static UpdateOrderServiceCommand ToCommandFromResource(UpdateOrderServiceResource resource, int orderServiceId)
    {
        return new UpdateOrderServiceCommand(
            orderServiceId,
            resource.ServiceId,
            resource.ServiceCategoryName,
            resource.ServiceTypeName,
            resource.Details,
            resource.Price
        );
    }
}