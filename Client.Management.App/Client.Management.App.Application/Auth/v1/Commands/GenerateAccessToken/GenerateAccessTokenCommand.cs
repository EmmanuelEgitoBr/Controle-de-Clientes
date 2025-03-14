using Client.Management.App.Api.Models.v1;
using MediatR;

namespace Client.Management.App.Application.Auth.v1.Commands.GenerateAccessToken;

public record GenerateAccessTokenCommand : IRequest<Response<string>>
{
    public string? Username { get; set; }

    public string? Password { get; set; }
}
