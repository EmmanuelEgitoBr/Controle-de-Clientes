using System.Text.Json.Serialization;

namespace Client.Management.App.Api.Services.Dtos.v1;

public record LoginRequestDto
{
    [JsonPropertyName("username")]
    public string? Username { get; init; }

    [JsonPropertyName("password")]
    public string? Password { get; init; }
}
