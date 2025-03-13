using Client.Management.App.Api.Models.v1;
using Client.Management.App.Api.Services.Dtos.v1;
using Client.Management.App.Application.Models.v1;
using Client.Management.App.Application.Services.Token.Commands.v1;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Client.Management.App.Api.Controllers.v1;

[Route("api/v1/token")]
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

    [HttpPost]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    public Task<Response<string>> Login([FromBody] LoginRequestDto generateTokenRequestDto)
    {
        var tokenSettings = new AuthTokenSettings
        {
            SecretKey = _configuration.GetSection("JWT").GetValue<string>("SecretKey"),
            TokenValidityInMinutes = _configuration.GetSection("JWT").GetValue<int>("TokenValidityInMinutes"),
            ValidAudience = _configuration.GetSection("JWT").GetValue<string>("ValidAudience"),
            ValidIssuer = _configuration.GetSection("JWT").GetValue<string>("ValidIssuer")
        };

        var command = new GenerateTokenCommand
        {
            Username = generateTokenRequestDto.Username,
            Settings = tokenSettings
        };

        return _mediator.Send(command);
    }
}
