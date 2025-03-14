using Client.Management.App.Api.Models.v1;
using Client.Management.App.Application.Auth.v1.Commands.GenerateAccessToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Client.Management.App.Api.Controllers.v1;

[Route("api/v1/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IMediator _mediator;

    public AuthController(IConfiguration configuration, IMediator mediator)
    {
        _configuration = configuration;
        _mediator = mediator;
    }

    [HttpPost("access-token")]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    public Task<Response<string>> Login([FromBody] GenerateAccessTokenCommand command)
    {
        return _mediator.Send(command);
    }
}
