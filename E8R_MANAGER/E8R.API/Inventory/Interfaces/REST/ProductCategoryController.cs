using E8R.API.Inventory.Domain.Model.Queries;
using E8R.API.Inventory.Domain.Services;
using E8R.API.Inventory.Interfaces.REST.Resources;
using E8R.API.Inventory.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace E8R.API.Inventory.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductCategoryController(IProductCategoryCommandService productCategoryCommandService, IProductCategoryQueryService productCategoryQueryService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllProductCategories()
    {
        var query = new GetAllProductCategoriesQuery();
        var productCategories = await productCategoryQueryService.Handle(query);
        var resources = productCategories.Select(ProductCategoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{productCategoryId}")]
    public async Task<IActionResult> GetProductCategoryById([FromRoute] int productCategoryId)
    {
        var productCategory = await productCategoryQueryService.Handle(new GetProductCategoryByIdQuery(productCategoryId));
        if (productCategory == null) return NotFound();
        var resource = ProductCategoryResourceFromEntityAssembler.ToResourceFromEntity(productCategory);
        return Ok(resource);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductCategory([FromBody] CreateProductCategoryResource createProductCategoryResource)
    {
        try
        {
            var command = CreateProductCategoryCommandFromResourceAssembler.ToCommandFromResource(createProductCategoryResource);
            var productCategory = await productCategoryCommandService.Handle(command);
            if (productCategory is null) return BadRequest();
            var resource = ProductCategoryResourceFromEntityAssembler.ToResourceFromEntity(productCategory);
            return CreatedAtAction(nameof(GetProductCategoryById), new { productCategoryId = resource.Id }, resource);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al crear la categoría de producto. " + e.Message });
        }
    }

    [HttpPut("{productCategoryId}")]
    public async Task<IActionResult> UpdateProductCategory([FromRoute] int productCategoryId, [FromBody] UpdateProductCategoryResource updateProductCategoryResource)
    {
        try
        {
            var command = UpdateProductCategoryCommandFromResourceAssembler.ToCommandFromResource(updateProductCategoryResource, productCategoryId);
            var productCategory = await productCategoryCommandService.Handle(command);
            if (productCategory is null) return NotFound();
            var resource = ProductCategoryResourceFromEntityAssembler.ToResourceFromEntity(productCategory);
            return Ok(resource);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al actualizar la categoría de producto. " + e.Message });
        }
    }

    [HttpDelete("{productCategoryId}")]
    public async Task<IActionResult> DeleteProductCategory([FromRoute] int productCategoryId)
    {
        try
        {
            var productCategory = await productCategoryQueryService.Handle(new GetProductCategoryByIdQuery(productCategoryId));
            if (productCategory == null) return NotFound();

            var resource = new DeleteProductCategoryResource(productCategoryId);
            var command = DeleteProductCategoryCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await productCategoryCommandService.Handle(command);
            if (!result) return BadRequest(new { message = "No se pudo eliminar la categoría de producto." });

            return Ok(new { message = $"La categoría de producto con id {productCategoryId} se ha borrado correctamente." });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al eliminar la categoría de producto. " + e.Message });
        }
    }
}
