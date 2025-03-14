using Client.Management.App.Api.Handlers.Auth.v1;
using Client.Management.App.Api.Services.Contracts.v1;
using Client.Management.App.Application.Auth.v1.Commands.GenerateAccessToken;
using Client.Management.App.Application.Services.Contracts.v1;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Refit;

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

        builder.Services.AddRefitClient<IClientsService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(configuration.GetSection("Api").GetValue<string>("BaseUrl")!));
    }

    public static IServiceCollection AddAuthConfiguration(this IServiceCollection services)
    {
        services.AddAuthentication("Bearer")
            .AddScheme<AuthenticationSchemeOptions, CustomTokenAuthenticationHandler>("Bearer", null);

        return services;
    }

    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Api Controle de Clientes", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Insira o token de autenticação no campo abaixo (sem 'Bearer')",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "CustomToken"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
        });

        return services;
    }
}
