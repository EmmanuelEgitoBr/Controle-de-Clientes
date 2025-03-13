using Client.Management.App.Api.Models.v1;
using Client.Management.App.Api.Services.Contracts.v1;
using Client.Management.App.Application.Resources.v1;
using Client.Management.App.Application.Services.Token.Commands.v1;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Client.Management.App.Application.Services.Token.Handlers.v1;

public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, Response<string>>
{
    private readonly IAuthTokenService _authTokenService;
    private ILogger<GenerateTokenCommandHandler> _logger;

    public GenerateTokenCommandHandler(IAuthTokenService authTokenService,
                                        ILogger<GenerateTokenCommandHandler> logger)
    {
        _authTokenService = authTokenService;
        _logger = logger;
    }

    public Task<Response<string>> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(LogTemplate.StartHandler, nameof(GenerateTokenCommandHandler));

        var token = _authTokenService.GenerateAccessToken(request.Username!, request.Settings!);
        var notifications = new List<string>();

        if (string.IsNullOrEmpty(token)) 
        {


            return Task.FromResult(new Response<string>
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Notifications = Message.ErrorGenerateToken
            });
        }

        _logger.LogInformation(LogTemplate.EndHandler, nameof(GenerateTokenCommandHandler));

        return Task.FromResult(new Response<string>
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Content = token
        });
    }
}
