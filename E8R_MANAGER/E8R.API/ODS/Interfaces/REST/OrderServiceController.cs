using E8R.API.ODS.Domain.Model.Queries;
using E8R.API.ODS.Domain.Services;
using E8R.API.ODS.Interfaces.REST.Resources;
using E8R.API.ODS.Interfaces.REST.Transform;
using E8R.API.Service.Domain.Services;
using E8R.API.Service.Domain.Model.Queries;
using Microsoft.AspNetCore.Mvc;

namespace E8R.API.ODS.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class OrderServiceController(
    IOrderServiceCommandService orderServiceCommandService, 
    IOrderServiceQueryService orderServiceQueryService,
    IServiceTypeQueryService serviceTypeQueryService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllOrderServices()
    {
        var query = new GetAllOrdersServiceQuery();
        var orderServices = await orderServiceQueryService.Handle(query);
        var resources = orderServices.Select(OrderServiceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{orderServiceId}")]
    public async Task<IActionResult> GetOrderServiceById([FromRoute] int orderServiceId)
    {
        var orderService = await orderServiceQueryService.Handle(new GetOrderServiceByIdQuery(orderServiceId));
        if (orderService == null) return NotFound();
        var resource = OrderServiceResourceFromEntityAssembler.ToResourceFromEntity(orderService);
        return Ok(resource);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderService([FromBody] CreateOrderServiceResourceAh createOrderServiceResource)
    {
        try
        {
            var command = CreateOrderServiceCommandFromResourceAssembler.ToCommandFromResource(createOrderServiceResource);
            var orderService = await orderServiceCommandService.Handle(command);
            if (orderService is null) return BadRequest();
            var resource = OrderServiceResourceFromEntityAssembler.ToResourceFromEntity(orderService);
            return CreatedAtAction(nameof(GetOrderServiceById), new { orderServiceId = resource.Id }, resource);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al crear el servicio de orden. " + e.Message });
        }
    }

    [HttpPut("{orderServiceId}")]
    public async Task<IActionResult> UpdateOrderService([FromRoute] int orderServiceId, [FromBody] UpdateOrderServiceResource updateOrderServiceResource)
    {
        try
        {
            var command = UpdateOrderServiceCommandFromResourceAssembler.ToCommandFromResource(updateOrderServiceResource, orderServiceId);
            var orderService = await orderServiceCommandService.Handle(command);
            if (orderService is null) return NotFound();
            var resource = OrderServiceResourceFromEntityAssembler.ToResourceFromEntity(orderService);
            return Ok(resource);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al actualizar el servicio de orden. " + e.Message });
        }
    }

    [HttpDelete("{orderServiceId}")]
    public async Task<IActionResult> DeleteOrderService([FromRoute] int orderServiceId)
    {
        try
        {
            var orderService = await orderServiceQueryService.Handle(new GetOrderServiceByIdQuery(orderServiceId));
            if (orderService == null) return NotFound();

            var resource = new DeleteOrderServiceResource(orderServiceId);
            var command = DeleteOrderServiceCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await orderServiceCommandService.Handle(command);
            if (!result) return BadRequest(new { message = "No se pudo eliminar el servicio de orden." });

            return Ok(new { message = $"El servicio de orden con id {orderServiceId} se ha borrado correctamente." });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al eliminar el servicio de orden. " + e.Message });
        }
    }

    [HttpGet("service-types/{serviceTypeId}")]
    public async Task<IActionResult> GetOrderServicesByServiceTypeId([FromRoute] int serviceTypeId)
    {
        var serviceType = await serviceTypeQueryService.Handle(new GetServiceTypeByIdQuery(serviceTypeId));
        if (serviceType == null) return NotFound(new { message = $"El tipo de servicio con id {serviceTypeId} no existe." });
        
        var query = new GetOrderServicesByServiceTypeIdQuery(serviceTypeId);
        var orderServices = await orderServiceQueryService.Handle(query);
        var resources = orderServices.Select(OrderServiceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}
