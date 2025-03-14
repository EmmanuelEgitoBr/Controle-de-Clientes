using System.Text.Json.Serialization;

namespace Client.Management.App.Application.Dtos.Auth.v1;

public record GenerateAccessTokenRequestDto
{
    [JsonPropertyName("username")]
    public string? Username { get; init; }

    [JsonPropertyName("password")]
    public string? Password { get; init; }
}
