using Client.Management.App.Api.Models.v1;
using Client.Management.App.Api.Services.Contracts.v1;
using Client.Management.App.Application.Dtos.Auth.v1;
using Client.Management.App.Application.Resources.v1;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace Client.Management.App.Application.Auth.v1.Commands.GenerateAccessToken;

public class GenerateAccessTokenCommandHandler : IRequestHandler<GenerateAccessTokenCommand, Response<string>>
{
    private readonly ILogger<GenerateAccessTokenCommandHandler> _logger;
    private readonly IAuthTokenService _authTokenService;

    public GenerateAccessTokenCommandHandler(ILogger<GenerateAccessTokenCommandHandler> logger, 
                                             IAuthTokenService authTokenService)
    {
        _logger = logger;
        _authTokenService = authTokenService;
    }

    public async Task<Response<string>> Handle(GenerateAccessTokenCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(LogTemplate.StartHandler, nameof(GenerateAccessTokenCommandHandler));

        var requestDto = new GenerateAccessTokenRequestDto
        {
            Username = request.Username,
            Password = request.Password
        };

        var result = await _authTokenService.GenerateTokenAsync(requestDto);

        if (!result.IsSuccessStatusCode)
        {
            _logger.LogError(LogTemplate.EndHandler, Message.ErrorGenerateToken);

            return new Response<string>
            {
                StatusCode = result.StatusCode,
                Notification = Message.ErrorGenerateToken
            };
        }

        var reponse = await result.Content.ReadFromJsonAsync<GenerateAccessTokenResponseDto>();

        _logger.LogInformation(LogTemplate.EndHandler, nameof(GenerateAccessTokenCommandHandler));

        return new Response<string>
        {
            Content = reponse!.Data!.Token,
            StatusCode = result.StatusCode
        };
    }
}
