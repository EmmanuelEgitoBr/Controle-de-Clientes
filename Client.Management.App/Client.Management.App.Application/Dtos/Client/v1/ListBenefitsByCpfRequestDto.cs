using System.Text.Json.Serialization;

namespace Client.Management.App.Application.Dtos.Client.v1;

public record ListBenefitsByCpfRequestDto
{
    [JsonPropertyName("cpf")]
    public string? DocumentNumber { get; init; }
}
