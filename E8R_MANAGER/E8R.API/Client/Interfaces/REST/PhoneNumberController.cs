using E8R.API.Client.Domain.Model.Queries;
using E8R.API.Client.Domain.Services;
using E8R.API.Client.Interfaces.REST.Resources;
using E8R.API.Client.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace E8R.API.Client.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class PhoneNumberController(
    IPhoneNumberCommandService phoneNumberCommandService, 
    IPhoneNumberQueryService phoneNumberQueryService, 
    ICustomerQueryService customerQueryService)
    :ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var query = new GetAllPhoneNumbersQuery();
        var phoneNumbers = await phoneNumberQueryService.Handle(query);
        var resources = phoneNumbers.Select(PhoneNumberResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{phoneNumberId}")]
    public async Task<IActionResult> GetPhoneNumberById([FromRoute] int phoneNumberId)
    {
        var phoneNumber = await phoneNumberQueryService.Handle(new GetPhoneNumberByIdQuery(phoneNumberId));
        if (phoneNumber == null) return NotFound();
        var resource = PhoneNumberResourceFromEntityAssembler.ToResourceFromEntity(phoneNumber);
        return Ok(resource);
    }
    
    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetPhoneNumbersByCustomerId([FromRoute] int customerId)
    {
        var customer = await customerQueryService.Handle(new GetCustomerByIdQuery(customerId));
        if (customer == null) return NotFound(new { message = "Customer Id no encontrado." });
        
        var query = new GetPhoneNumbersByCustomerIdQuery(customerId);
        var phoneNumbers = await phoneNumberQueryService.Handle(query);
        var resources = phoneNumbers.Select(PhoneNumberResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePhoneNumber([FromBody] CreatePhoneNumberResource createPhoneNumberResource)
    {
        try
        {
            var command = CreatePhoneNumberCommandFromResourceAssembler.ToCommandFromResource(createPhoneNumberResource);
            var phoneNumber = await phoneNumberCommandService.Handle(command);
            if (phoneNumber is null) return BadRequest();
            var resource = PhoneNumberResourceFromEntityAssembler.ToResourceFromEntity(phoneNumber);
            return CreatedAtAction(nameof(GetPhoneNumberById), new { phoneNumberId = resource.Id }, resource);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = $"Error: {e.GetType().Name} - {e.Message}" });
        }
    }
    
    [HttpPut("{phoneNumberId}")]
    public async Task<IActionResult> UpdatePhoneNumber([FromRoute] int phoneNumberId, [FromBody] UpdatePhoneNumberResource updatePhoneNumberResource)
    {
        try
        {
            var command = UpdatePhoneNumberCommandFromResourceAssembler.ToCommandFromResource(updatePhoneNumberResource, phoneNumberId);
            var phoneNumber = await phoneNumberCommandService.Handle(command);
            if (phoneNumber is null) return NotFound();
            var resource = PhoneNumberResourceFromEntityAssembler.ToResourceFromEntity(phoneNumber);
            return Ok(resource);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al actualizar el número. " + e.Message });
        }
    }
    
    [HttpDelete("{phoneNumberId}")]
    public async Task<IActionResult> DeletePhoneNumber([FromRoute] int phoneNumberId)
    {
        try
        {
            var phoneNumber = await phoneNumberQueryService.Handle(new GetPhoneNumberByIdQuery(phoneNumberId));
            if (phoneNumber == null) return NotFound();
    
            var resource = new DeletePhoneNumberResource(phoneNumberId);
            var command = DeletePhoneNumberCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await phoneNumberCommandService.Handle(command);
            if (!result) return BadRequest(new { message = "No se pudo eliminar el número." });
    
            return Ok(new { message = $"El número {phoneNumber.Number} del cliente {phoneNumber.CustomerId} se ha borrado correctamente." });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Ocurrió un error al eliminar el número. " + e.Message });
        }
    }
}