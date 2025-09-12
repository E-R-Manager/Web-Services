using E8R.API.ODS.Domain.Model.Queries;
using E8R.API.ODS.Domain.Services;
using E8R.API.ODS.Interfaces.REST.Resources;
using E8R.API.ODS.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace E8R.API.ODS.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class OrderController (IOrderCommandService orderCommandService, IOrderQueryService orderQueryService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var query = new GetAllOrdersQuery();
        var orders = await orderQueryService.Handle(query);
        var resources = orders.Select(OrderResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrderById([FromRoute] int orderId)
    {
        var order = await orderQueryService.Handle(new GetOrderByIdQuery(orderId));
        if (order == null) return NotFound();
        var resource = OrderResourceFromEntityAssembler.ToResourceFromEntity(order);
        return Ok(resource);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderResource createOrderResource)
    {
        try
        {
            var command = CreateOrderCommandFromResourceAssembler.ToCommandFromResource(createOrderResource);
            var order = await orderCommandService.Handle(command);
            if (order is null) return BadRequest();
            var resource = OrderResourceFromEntityAssembler.ToResourceFromEntity(order);
            return CreatedAtAction(nameof(GetOrderById), new { orderId = resource.Id }, resource);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al crear la orden. " + e.Message });
        }
    }

    [HttpPut("{orderId}")]
    public async Task<IActionResult> UpdateOrder([FromRoute] int orderId, [FromBody] UpdateOrderResource updateOrderResource)
    {
        try
        {
            var command = UpdateOrderCommandFromResourceAssembler.ToCommandFromResource(updateOrderResource, orderId);
            var order = await orderCommandService.Handle(command);
            if (order is null) return NotFound();
            var resource = OrderResourceFromEntityAssembler.ToResourceFromEntity(order);
            return Ok(resource);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al actualizar la orden. " + e.Message });
        }
    }
    
    [HttpDelete("{orderId}")]
    public async Task<IActionResult> DeleteOrder([FromRoute] int orderId)
    {
        try
        {
            var product = await orderQueryService.Handle(new GetOrderByIdQuery(orderId));
            if (product == null) return NotFound();

            var resource = new DeleteOrderResource(orderId);
            var command = DeleteOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await orderCommandService.Handle(command);
            if (!result) return BadRequest(new { message = "No se pudo eliminar la orden." });

            return Ok(new { message = $"El producto con id {orderId} se ha borrado correctamente." });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al eliminar la orden. " + e.Message });
        }
    }
}