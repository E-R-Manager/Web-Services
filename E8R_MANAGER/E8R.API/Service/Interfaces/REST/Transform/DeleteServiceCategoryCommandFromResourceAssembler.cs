using E8R.API.Service.Domain.Model.Commands;
using E8R.API.Service.Interfaces.REST.Resources;

namespace E8R.API.Service.Interfaces.REST.Transform;

public static class DeleteServiceCategoryCommandFromResourceAssembler
{
    public static DeleteServiceCategoryCommand ToCommandFromResource(DeleteServiceCategoryResource resource)
    {
        return new DeleteServiceCategoryCommand(resource.ServiceCategoryId);
    }
}