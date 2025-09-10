using E8R.API.Inventory.Domain.Model.Entities;
using E8R.API.Inventory.Domain.Model.Queries;

namespace E8R.API.Inventory.Domain.Services;

public interface IProductCategoryQueryService
{
    Task<IEnumerable<ProductCategory>> Handle(GetAllProductCategoriesQuery query);
    Task<ProductCategory?> Handle(GetProductCategoryByIdQuery query);
}