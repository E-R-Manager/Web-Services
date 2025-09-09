using E8R.API.Client.Domain.Model.Queries;
using E8R.API.Client.Domain.Services;
using E8R.API.Client.Interfaces.REST.Resources;
using E8R.API.Client.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace E8R.API.Client.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController(ICustomerCommandService customerCommandService, ICustomerQueryService customerQueryService)
    :ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var query = new GetAllCustomersQuery();
        var customers = await customerQueryService.Handle(query);
        var resources = customers.Select(CustomerResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    [HttpGet("{customerId}")]
    public async Task<IActionResult> GetCustomerById([FromRoute] int customerId)
    {
        var customer = await customerQueryService.Handle(new GetCustomerByIdQuery(customerId));
        if (customer == null) return NotFound();
        var resource = CustomerResourceFromEntityAssembler.ToResourceFromEntity(customer);
        return Ok(resource);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerResource createCustomerResource)
    {
        try
        {
            var command = CreateCustomerCommandFromResourceAssembler.ToCommandFromResource(createCustomerResource);
            var customer = await customerCommandService.Handle(command);
            if (customer is null) return BadRequest();
            var resource = CustomerResourceFromEntityAssembler.ToResourceFromEntity(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { customerId = resource.Id }, resource);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al crear el cliente. " + e.Message });
        }
    }
    [HttpPut("{customerId}")]
    public async Task<IActionResult> UpdateCustomer([FromRoute] int customerId, [FromBody] UpdateCustomerResource updateCustomerResource)
    {
        try
        {
            var command = UpdateCustomerCommandFromResourceAssembler.ToCommandFromResource(updateCustomerResource, customerId);
            var customer = await customerCommandService.Handle(command);
            if (customer is null) return NotFound();
            var resource = CustomerResourceFromEntityAssembler.ToResourceFromEntity(customer);
            return Ok(resource);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al actualizar el cliente. " + e.Message });
        }
    }
    [HttpDelete("{customerId}")]
    public async Task<IActionResult> DeleteCustomer([FromRoute] int customerId)
    {
        try
        {
            var customer = await customerQueryService.Handle(new GetCustomerByIdQuery(customerId));
            if (customer == null) return NotFound();

            var resource = new DeleteCustomerResource(customerId);
            var command = DeleteCustomerCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await customerCommandService.Handle(command);
            if (!result) return BadRequest(new { message = "No se pudo eliminar el cliente." });

            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al eliminar el cliente. " + e.Message });
        }
    }
}