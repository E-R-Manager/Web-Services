using E8R.API.Service.Domain.Model.Queries;
using E8R.API.Service.Domain.Services;
using E8R.API.Service.Interfaces.REST.Resources;
using E8R.API.Service.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace E8R.API.Service.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ServiceTypeController(
    IServiceTypeCommandService serviceTypeCommandService, 
    IServiceTypeQueryService serviceTypeQueryService,
    IServiceCategoryQueryService serviceCategoryQueryService)
    :ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllServiceTypes()
    {
        var query = new GetAllServiceTypesQuery();
        var serviceTypes = await serviceTypeQueryService.Handle(query);
        var resources = serviceTypes.Select(ServiceTypeResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{serviceTypeId}")]
    public async Task<IActionResult> GetServiceTypeById([FromRoute] int serviceTypeId)
    {
        var serviceType = await serviceTypeQueryService.Handle(new GetServiceTypeByIdQuery(serviceTypeId));
        if (serviceType == null) return NotFound();
        var resource = ServiceTypeResourceFromEntityAssembler.ToResourceFromEntity(serviceType);
        return Ok(resource);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateServiceType([FromBody] CreateServiceTypeResource createServiceTypeResource)
    {
        try
        {
            var command = CreateServiceTypeCommandFromResourceAssembler.ToCommandFromResource(createServiceTypeResource);
            var serviceType = await serviceTypeCommandService.Handle(command);
            if (serviceType is null) return BadRequest();
            var resource = ServiceTypeResourceFromEntityAssembler.ToResourceFromEntity(serviceType);
            return CreatedAtAction(nameof(GetServiceTypeById), new { serviceTypeId = resource.Id }, resource);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = $"Error: {e.GetType().Name} - {e.Message}" });
        }
    }
    
    [HttpPut("{serviceTypeId}")]
    public async Task<IActionResult> UpdateServiceType([FromRoute] int serviceTypeId, [FromBody] UpdateServiceTypeResource updateServiceTypeResource)
    {
        try
        {
            var command = UpdateServiceTypeCommandFromResourceAssembler.ToCommandFromResource(updateServiceTypeResource, serviceTypeId);
            var serviceType = await serviceTypeCommandService.Handle(command);
            if (serviceType is null) return NotFound();
            var resource = ServiceTypeResourceFromEntityAssembler.ToResourceFromEntity(serviceType);
            return Ok(resource);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al actualizar el tipo de servicio. " + e.Message });
        }
    }
    
    [HttpDelete("{serviceTypeId}")]
    public async Task<IActionResult> DeleteServiceType([FromRoute] int serviceTypeId)
    {
        try
        {
            var serviceType = await serviceTypeQueryService.Handle(new GetServiceTypeByIdQuery(serviceTypeId));
            if (serviceType == null) return NotFound();
    
            var resource = new DeleteServiceTypeResource(serviceTypeId);
            var command = DeleteServiceTypeCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await serviceTypeCommandService.Handle(command);
            if (!result) return BadRequest(new { message = "No se pudo eliminar el tipo de servicio." });
    
            return Ok(new { message = $"El tipo de servicio {serviceType.Name} se ha borrado correctamente." });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al eliminar el tipo de servicio. " + e.Message });
        }
    }
}