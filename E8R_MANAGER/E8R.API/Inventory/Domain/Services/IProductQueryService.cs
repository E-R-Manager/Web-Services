using E8R.API.Inventory.Domain.Model.Aggregates;
using E8R.API.Inventory.Domain.Model.Queries;

namespace E8R.API.Inventory.Domain.Services;

public interface IProductQueryService
{
    Task <IEnumerable<Product>> Handle(GetAllProductsQuery query);
    Task <Product?> Handle(GetProductByIdQuery query);
    Task<IEnumerable<Product>> Handle(GetProductsByProductTypeIdQuery query);
}