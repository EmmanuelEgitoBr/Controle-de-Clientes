using Client.Management.App.Api.Models.v1;
using Client.Management.App.Application.Models.v1;
using MediatR;

namespace Client.Management.App.Application.Services.Token.Commands.v1;

public record GenerateTokenCommand : IRequest<Response<string>>
{
    public string? Username { get; set; }
    public AuthTokenSettings? Settings { get; set; }
}
