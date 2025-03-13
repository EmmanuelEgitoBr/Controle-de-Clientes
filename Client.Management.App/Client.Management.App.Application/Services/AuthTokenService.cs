using Client.Management.App.Api.Services.Contracts.v1;
using Client.Management.App.Application.Models.v1;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Client.Management.App.Application.Services;

public class AuthTokenService : IAuthTokenService
{
    public string GenerateAccessToken(string username, AuthTokenSettings settings)
    {
        var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username!),
                    new Claim("id", username!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

        var token = new JwtSecurityTokenHandler().WriteToken(GenerateAuthToken(authClaims, settings));

        return token;
    }

    private JwtSecurityToken GenerateAuthToken(IEnumerable<Claim> claims, AuthTokenSettings settings)
    {
        var Key = settings.SecretKey ??
                throw new InvalidOperationException("Invalid secret key");

        var privateKey = Encoding.UTF8.GetBytes(Key);

        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(privateKey),
            SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(settings.TokenValidityInMinutes),
            Audience = settings.ValidAudience,
            Issuer = settings.ValidIssuer,
            SigningCredentials = signingCredentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

        return token;
    }
}
