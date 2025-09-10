using E8R.API.Service.Domain.Model.Queries;
using E8R.API.Service.Domain.Services;
using E8R.API.Service.Interfaces.REST.Resources;
using E8R.API.Service.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace E8R.API.Service.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ServiceCategoryController(
    IServiceCategoryCommandService serviceCategoryCommandService, 
    IServiceCategoryQueryService serviceCategoryQueryService)
    :ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllServiceCategories()
    {
        var query = new GetAllServiceCategoriesQuery();
        var serviceCategories = await serviceCategoryQueryService.Handle(query);
        var resources = serviceCategories.Select(ServiceCategoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{serviceCategoryId}")]
    public async Task<IActionResult> GetServiceCategoryById([FromRoute] int serviceCategoryId)
    {
        var serviceCategory = await serviceCategoryQueryService.Handle(new GetServiceCategoryByIdQuery(serviceCategoryId));
        if (serviceCategory == null) return NotFound();
        var resource = ServiceCategoryResourceFromEntityAssembler.ToResourceFromEntity(serviceCategory);
        return Ok(resource);
    }

    [HttpPost]
    public async Task<IActionResult> CreateServiceCategory(
        [FromBody] CreateServiceCategoryResource createServiceCategoryResource)
    {
        try
        {
            var command = CreateServiceCategoryCommandFromResourceAssembler.ToCommandFromResource(createServiceCategoryResource);
            var serviceCategory = await serviceCategoryCommandService.Handle(command);
            if (serviceCategory == null) return BadRequest();
            var resource = ServiceCategoryResourceFromEntityAssembler.ToResourceFromEntity(serviceCategory);
            return CreatedAtAction(nameof(GetServiceCategoryById), new { serviceCategoryId = resource.Id }, resource);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = $"Error: {e.GetType().Name} - {e.Message}" });
        }
    }
    
    [HttpPut("{serviceCategoryId}")]
    public async Task<IActionResult> UpdateServiceCategory([FromRoute] int serviceCategoryId, [FromBody] UpdateServiceCategoryResource updateServiceCategoryResource)
    {
        try
        {
            var command = UpdateServiceCategoryCommandFromResourceAssembler.ToCommandFromResource(updateServiceCategoryResource, serviceCategoryId);
            var serviceCategory = await serviceCategoryCommandService.Handle(command);
            if (serviceCategory == null) return NotFound();
            var resource = ServiceCategoryResourceFromEntityAssembler.ToResourceFromEntity(serviceCategory);
            return Ok(resource);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = $"Error: {e.GetType().Name} - {e.Message}" });
        }
    }

    [HttpDelete("{serviceCategoryId}")]
    public async Task<IActionResult> DeleteServiceCategory([FromRoute] int serviceCategoryId)
    {
        try
        {
            var serviceCategory = await serviceCategoryQueryService.Handle(new GetServiceCategoryByIdQuery(serviceCategoryId));
            if (serviceCategory == null) return NotFound();
    
            var resource = new DeleteServiceCategoryResource(serviceCategoryId);
            var command = DeleteServiceCategoryCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await serviceCategoryCommandService.Handle(command);
            if (!result) return BadRequest(new { message = "No se pudo eliminar la categoria de servicio." });
    
            return Ok(new { message = $"La categoria de servicio {serviceCategory.Name} se ha borrado correctamente." });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al eliminar la categoria de servicio. " + e.Message });
        }
    }
    
}