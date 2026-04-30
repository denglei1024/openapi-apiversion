using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using OpenApi_ApiVersion.Contracts.V2.Users;
using OpenApi_ApiVersion.Services.Users;

namespace OpenApi_ApiVersion.Controllers.V2;

[ApiController]
[ApiVersion("2.0")]
[ApiExplorerSettings(GroupName = "v2")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces("application/json")]
public sealed class UsersController(IUserQueryService userQueryService) : ControllerBase
{
    [HttpGet]
    [MapToApiVersion("2.0")]
    [ProducesResponseType(typeof(IReadOnlyList<UserListItemResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public ActionResult<IReadOnlyList<UserListItemResponse>> Get()
    {
        var response = userQueryService
            .GetUsers()
            .Select(user => new UserListItemResponse(user.Id, user.Name, user.Email))
            .ToArray();

        return Ok(response);
    }
}

