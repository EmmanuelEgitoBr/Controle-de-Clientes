using Client.Management.App.Application.Models.v1;

namespace Client.Management.App.Api.Services.Contracts.v1;

public interface IAuthTokenService
{
    string GenerateAccessToken(string username, AuthTokenSettings settings);
}