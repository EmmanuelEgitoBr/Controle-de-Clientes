using Client.Management.App.Api.Services.Contracts.v1;
using Client.Management.App.Application.Auth.v1.Commands.GenerateAccessToken;
using Refit;
using System.Net.Http.Headers;

namespace Client.Management.App.Api.Extensions.v1;

public static class BuilderExtensions
{
    public static void AddMediatorConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(GenerateAccessTokenCommand).Assembly));
    }

    public static void AddRefitConfiguration(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        builder.Services.AddRefitClient<IAuthTokenService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(configuration.GetSection("Api").GetValue<string>("BaseUrl")!));
    }
}
