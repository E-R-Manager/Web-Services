using System.Net.Mime;
using E8R.API.IAM.Domain.Model.Queries;
using E8R.API.IAM.Domain.Services;
using E8R.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Microsoft.AspNetCore.Mvc;
using UserResourceFromEntityAssembler = E8R.API.IAM.Interfaces.REST.Transform.UserResourceFromEntityAssembler;

namespace E8R.API.IAM.Interfaces.REST;

/**
 * <summary>
 *     The users controller
 * </summary>
 * <remarks>
 *     This class is used to handle user requests
 * </remarks>
 */
[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UsersController(IUserQueryService userQueryService, IUserCommandService userCommandService) : ControllerBase
{
    /**
     * <summary>
     *     Get user by id endpoint. It allows to get a user by id
     * </summary>
     * <param name="userId">The user id</param>
     * <returns>The user resource</returns>
     */
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var user = await userQueryService.Handle(getUserByIdQuery);
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user!);
        return Ok(userResource);
    }
    
    /**
     * <summary>
     *     Get all users endpoint. It allows to get all users
     * </summary>
     * <returns>The user resources</returns>
     */
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var getAllUsersQuery = new GetAllUsersQuery();
        var users = await userQueryService.Handle(getAllUsersQuery);
        var userResources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(userResources);
    }
}