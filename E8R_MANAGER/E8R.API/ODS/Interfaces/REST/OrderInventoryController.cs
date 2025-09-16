using E8R.API.ODS.Domain.Model.Queries;
using E8R.API.ODS.Domain.Services;
using E8R.API.ODS.Interfaces.REST.Resources;
using E8R.API.ODS.Interfaces.REST.Transform;
using E8R.API.Inventory.Domain.Services;
using E8R.API.Inventory.Domain.Model.Queries;
using Microsoft.AspNetCore.Mvc;

namespace E8R.API.ODS.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class OrderInventoryController(
    IOrderInventoryCommandService orderInventoryCommandService, 
    IOrderInventoryQueryService orderInventoryQueryService,
    IProductQueryService productQueryService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllOrderInventories()
    {
        var query = new GetAllOrdersInventoryQuery();
        var orderInventories = await orderInventoryQueryService.Handle(query);
        var resources = orderInventories.Select(OrderInventoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{orderInventoryId}")]
    public async Task<IActionResult> GetOrderInventoryById([FromRoute] int orderInventoryId)
    {
        var orderInventory = await orderInventoryQueryService.Handle(new GetOrderInventoryByIdQuery(orderInventoryId));
        if (orderInventory == null) return NotFound();
        var resource = OrderInventoryResourceFromEntityAssembler.ToResourceFromEntity(orderInventory);
        return Ok(resource);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderInventory([FromBody] CreateOrderInventoryResource createOrderInventoryResource)
    {
        try
        {
            var command = CreateOrderInventoryCommandFromResourceAssembler.ToCommandFromResource(createOrderInventoryResource);
            var orderInventory = await orderInventoryCommandService.Handle(command);
            if (orderInventory is null) return BadRequest();
            var resource = OrderInventoryResourceFromEntityAssembler.ToResourceFromEntity(orderInventory);
            return CreatedAtAction(nameof(GetOrderInventoryById), new { orderInventoryId = resource.Id }, resource);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al crear el inventario de orden. " + e.Message });
        }
    }

    [HttpPut("{orderInventoryId}")]
    public async Task<IActionResult> UpdateOrderInventory([FromRoute] int orderInventoryId, [FromBody] UpdateOrderInventoryResource updateOrderInventoryResource)
    {
        try
        {
            var command = UpdateOrderInventoryCommandFromResourceAssembler.ToCommandFromResource(updateOrderInventoryResource, orderInventoryId);
            var orderInventory = await orderInventoryCommandService.Handle(command);
            if (orderInventory is null) return NotFound();
            var resource = OrderInventoryResourceFromEntityAssembler.ToResourceFromEntity(orderInventory);
            return Ok(resource);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al actualizar el inventario de orden. " + e.Message });
        }
    }

    [HttpDelete("{orderInventoryId}")]
    public async Task<IActionResult> DeleteOrderInventory([FromRoute] int orderInventoryId)
    {
        try
        {
            var orderInventory = await orderInventoryQueryService.Handle(new GetOrderInventoryByIdQuery(orderInventoryId));
            if (orderInventory == null) return NotFound();

            var resource = new DeleteOrderInventoryResource(orderInventoryId);
            var command = DeleteOrderInventoryCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await orderInventoryCommandService.Handle(command);
            if (!result) return BadRequest(new { message = "No se pudo eliminar el inventario de orden." });

            return Ok(new { message = $"El inventario de orden con id {orderInventoryId} se ha borrado correctamente." });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al eliminar el inventario de orden. " + e.Message });
        }
    }

    [HttpGet("product/{productId}")]
    public async Task<IActionResult> GetOrderInventoriesByProductId([FromRoute] int productId)
    {
        var product = await productQueryService.Handle(new GetProductByIdQuery(productId));
        if (product == null) return NotFound(new { message = $"No se encontró el producto con id {productId}." });
        
        var query = new GetOrderInventoriesByProductIdQuery(productId);
        var orderInventories = await orderInventoryQueryService.Handle(query);
        var resources = orderInventories.Select(OrderInventoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}
