using Client.Management.App.Application.Dtos.Auth.v1;
using Refit;

namespace Client.Management.App.Api.Services.Contracts.v1;

[Headers("Content-Type: application/json", "Accept: application/json")]
public interface IAuthTokenService
{
    [Post("/api/v1/token")]
    Task<HttpResponseMessage> GenerateTokenAsync([Body] GenerateAccessTokenRequestDto authLoginRequestDto);
}