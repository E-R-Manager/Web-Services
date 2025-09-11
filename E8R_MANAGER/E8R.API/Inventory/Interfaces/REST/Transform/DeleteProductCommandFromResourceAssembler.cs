using E8R.API.Inventory.Domain.Model.Commands;
using E8R.API.Inventory.Interfaces.REST.Resources;
namespace E8R.API.Inventory.Interfaces.REST.Transform;

public static class DeleteProductCommandFromResourceAssembler
{
    public static DeleteProductCommand ToCommandFromResource(DeleteProductResource resource)
    {
        return new DeleteProductCommand(resource.ProductId);
    }
}