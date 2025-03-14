using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Client.Management.App.Api.Handlers.Auth.v1;

public class CustomTokenAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public CustomTokenAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder) : base(options, logger, encoder)
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
            return AuthenticateResult.Fail("Cabeçalho de autorização ausente.");

        var authorizationHeader = Request.Headers["Authorization"].ToString();

        if (!authorizationHeader.StartsWith("Bearer "))
            return AuthenticateResult.Fail("Formato de token inválido.");

        var token = authorizationHeader["Bearer ".Length..];

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, "usuario_demo"),
            new Claim(ClaimTypes.Role, "Admin") // Pode adicionar permissões personalizadas
        };

        var identity = new ClaimsIdentity(claims, "Bearer");
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, "Bearer");

        return AuthenticateResult.Success(ticket);
    }
}
