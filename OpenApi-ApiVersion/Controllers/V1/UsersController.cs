using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using OpenApi_ApiVersion.Contracts.V1.Users;
using OpenApi_ApiVersion.Services.Users;

namespace OpenApi_ApiVersion.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "v1")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces("application/json")]
public sealed class UsersController(IUserQueryService userQueryService) : ControllerBase
{
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(typeof(IReadOnlyList<UserListItemResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public ActionResult<IReadOnlyList<UserListItemResponse>> Get()
    {
        var response = userQueryService
            .GetUsers()
            .Select(user => new UserListItemResponse(user.Id, user.Name))
            .ToArray();

        return Ok(response);
    }
}

