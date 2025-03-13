using Client.Management.App.Api.Services.Contracts.v1;
using Client.Management.App.Application.Services;
using Client.Management.App.Application.Services.Token.Commands.v1;

namespace Client.Management.App.Api.Extensions.v1;

public static class BuilderExtensions
{
    public static void AddMediatorConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(GenerateTokenCommand).Assembly));
    }

    public static void AddApplicationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthTokenService, AuthTokenService>();
    }
}
