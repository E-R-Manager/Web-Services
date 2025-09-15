using E8R.API.Inventory.Domain.Model.Entities;
using E8R.API.Inventory.Domain.Model.Queries;

namespace E8R.API.Inventory.Domain.Services;

public interface IProductTypeQueryService
{
    Task<IEnumerable<ProductType>> Handle(GetAllProductTypesQuery query);
    Task<ProductType?> Handle(GetProductTypeByIdQuery query);
    Task<IEnumerable<ProductType>> Handle(GetProductTypesByProductCategoryIdQuery query);
}