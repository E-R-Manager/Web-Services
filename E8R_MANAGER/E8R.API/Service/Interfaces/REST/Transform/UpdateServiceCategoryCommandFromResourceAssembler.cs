using E8R.API.Service.Domain.Model.Commands;
using E8R.API.Service.Interfaces.REST.Resources;

namespace E8R.API.Service.Interfaces.REST.Transform;

public static class UpdateServiceCategoryCommandFromResourceAssembler
{
    public static UpdateServiceCategoryCommand ToCommandFromResource(UpdateServiceCategoryResource resource, int serviceCategoryId)
    {
        return new UpdateServiceCategoryCommand(
            serviceCategoryId,
            resource.Name,
            resource.ContractedAmount
        );
    }
}