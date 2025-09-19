using E8R.API.Client.Domain.Model.Queries;
using E8R.API.ODS.Domain.Model.Queries;
using E8R.API.ODS.Domain.Services;
using E8R.API.ODS.Interfaces.REST.Resources;
using E8R.API.ODS.Interfaces.REST.Transform;
using E8R.API.Client.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace E8R.API.ODS.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class OrderController (
    IOrderCommandService orderCommandService, 
    IOrderQueryService orderQueryService,
    ICustomerQueryService customerQueryService)
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

    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetOrdersByCustomerId([FromRoute] int customerId)
    {
        var customer = await customerQueryService.Handle(new GetCustomerByIdQuery(customerId));
        if (customer == null) return NotFound(new { message = $"No se encontró el cliente con id {customerId}." });
        
        var query = new GetOrdersByCustomerIdQuery(customerId);
        var orders = await orderQueryService.Handle(query);
        var resources = orders.Select(OrderResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("order-date/{orderDate}")]
    public async Task<IActionResult> GetOrdersByOrderDate([FromRoute] DateOnly orderDate)
    {
        var query = new GetOrdersByOrderDateQuery(orderDate);
        var orders = await orderQueryService.Handle(query);
        var resources = orders.Select(OrderResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("order-state/{orderState}")]
    public async Task<IActionResult> GetOrdersByOrderState([FromRoute] string orderState)
    {
        if (!Enum.TryParse(orderState, true, out Domain.Model.ValueObjects.OrderState parsedOrderState))
        {
            return BadRequest(new { message = $"Estado de orden inválido: {orderState}. Valores válidos: Proforma, Cancelado, Anulado." });
        }

        var query = new GetOrdersByOrderStateQuery(parsedOrderState);
        var orders = await orderQueryService.Handle(query);
        var resources = orders.Select(OrderResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}