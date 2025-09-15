using E8R.API.Inventory.Domain.Model.Queries;
using E8R.API.Inventory.Domain.Services;
using E8R.API.Inventory.Interfaces.REST.Resources;
using E8R.API.Inventory.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace E8R.API.Inventory.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductController(
    IProductCommandService productCommandService, 
    IProductQueryService productQueryService,
    IProductTypeQueryService productTypeQueryService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var query = new GetAllProductsQuery();
        var products = await productQueryService.Handle(query);
        var resources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProductById([FromRoute] int productId)
    {
        var product = await productQueryService.Handle(new GetProductByIdQuery(productId));
        if (product == null) return NotFound();
        var resource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return Ok(resource);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductResource createProductResource)
    {
        try
        {
            var command = CreateProductCommandFromResourceAssembler.ToCommandFromResource(createProductResource);
            var product = await productCommandService.Handle(command);
            if (product is null) return BadRequest();
            var resource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
            return CreatedAtAction(nameof(GetProductById), new { productId = resource.Id }, resource);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al crear el producto. " + e.Message });
        }
    }

    [HttpPut("{productId}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] int productId, [FromBody] UpdateProductResource updateProductResource)
    {
        try
        {
            var command = UpdateProductCommandFromResourceAssembler.ToCommandFromResource(updateProductResource, productId);
            var product = await productCommandService.Handle(command);
            if (product is null) return NotFound();
            var resource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
            return Ok(resource);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al actualizar el producto. " + e.Message });
        }
    }

    [HttpDelete("{productId}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
    {
        try
        {
            var product = await productQueryService.Handle(new GetProductByIdQuery(productId));
            if (product == null) return NotFound();

            var resource = new DeleteProductResource(productId);
            var command = DeleteProductCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await productCommandService.Handle(command);
            if (!result) return BadRequest(new { message = "No se pudo eliminar el producto." });

            return Ok(new { message = $"El producto con id {productId} se ha borrado correctamente." });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al eliminar el producto. " + e.Message });
        }
    }

    [HttpGet("product-type/{productTypeId}")]
    public async Task<IActionResult> GetProductsByProductTypeId([FromRoute] int productTypeId)
    {
        var productType = await productTypeQueryService.Handle(new GetProductTypeByIdQuery(productTypeId));
        if (productType == null) return NotFound(new { message = $"No se encontró el tipo de producto con id {productTypeId}." });
        
        var query = new GetProductsByProductTypeIdQuery(productTypeId);
        var products = await productQueryService.Handle(query);
        var resources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}
