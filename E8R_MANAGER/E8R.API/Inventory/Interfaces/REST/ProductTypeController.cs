using E8R.API.Inventory.Domain.Model.Queries;
using E8R.API.Inventory.Domain.Services;
using E8R.API.Inventory.Interfaces.REST.Resources;
using E8R.API.Inventory.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace E8R.API.Inventory.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductTypeController(
    IProductTypeCommandService productTypeCommandService, 
    IProductTypeQueryService productTypeQueryService,
    IProductCategoryQueryService productCategoryQueryService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllProductTypes()
    {
        var query = new GetAllProductTypesQuery();
        var productTypes = await productTypeQueryService.Handle(query);
        var resources = productTypes.Select(ProductTypeResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{productTypeId}")]
    public async Task<IActionResult> GetProductTypeById([FromRoute] int productTypeId)
    {
        var productType = await productTypeQueryService.Handle(new GetProductTypeByIdQuery(productTypeId));
        if (productType == null) return NotFound();
        var resource = ProductTypeResourceFromEntityAssembler.ToResourceFromEntity(productType);
        return Ok(resource);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductType([FromBody] CreateProductTypeResource createProductTypeResource)
    {
        try
        {
            var command = CreateProductTypeCommandFromResourceAssembler.ToCommandFromResource(createProductTypeResource);
            var productType = await productTypeCommandService.Handle(command);
            if (productType is null) return BadRequest();
            var resource = ProductTypeResourceFromEntityAssembler.ToResourceFromEntity(productType);
            return CreatedAtAction(nameof(GetProductTypeById), new { productTypeId = resource.Id }, resource);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al crear el tipo de producto. " + e.Message });
        }
    }

    [HttpPut("{productTypeId}")]
    public async Task<IActionResult> UpdateProductType([FromRoute] int productTypeId, [FromBody] UpdateProductTypeResource updateProductTypeResource)
    {
        try
        {
            var command = UpdateProductTypeCommandFromResourceAssembler.ToCommandFromResource(updateProductTypeResource, productTypeId);
            var productType = await productTypeCommandService.Handle(command);
            if (productType is null) return NotFound();
            var resource = ProductTypeResourceFromEntityAssembler.ToResourceFromEntity(productType);
            return Ok(resource);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al actualizar el tipo de producto. " + e.Message });
        }
    }

    [HttpDelete("{productTypeId}")]
    public async Task<IActionResult> DeleteProductType([FromRoute] int productTypeId)
    {
        try
        {
            var productType = await productTypeQueryService.Handle(new GetProductTypeByIdQuery(productTypeId));
            if (productType == null) return NotFound();

            var resource = new DeleteProductTypeResource(productTypeId);
            var command = DeleteProductTypeCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await productTypeCommandService.Handle(command);
            if (!result) return BadRequest(new { message = "No se pudo eliminar el tipo de producto." });

            return Ok(new { message = $"El tipo de producto con id {productTypeId} se ha borrado correctamente." });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al eliminar el tipo de producto. " + e.Message });
        }
    }

    [HttpGet("product-category/{productCategoryId}")]
    public async Task<IActionResult> GetProductTypesByProductCategoryId([FromRoute] int productCategoryId)
    {
        var productCategory = await productCategoryQueryService.Handle(new GetProductCategoryByIdQuery(productCategoryId));
        if (productCategory == null) return NotFound(new { message = "Product Category Id no encontrado." });

        var query = new GetProductTypesByProductCategoryIdQuery(productCategoryId);
        var productTypes = await productTypeQueryService.Handle(query);
        var resources = productTypes.Select(ProductTypeResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}
