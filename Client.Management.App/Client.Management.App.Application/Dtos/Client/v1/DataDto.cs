using System.Text.Json.Serialization;

namespace Client.Management.App.Application.Dtos.Client.v1;

public record DataDto
{
    [JsonPropertyName("cpf")]
    public string documentNumber { get; set; } = string.Empty;

    [JsonPropertyName("beneficios")]
    public List<BenefitDto> Benefits { get; set; } = new List<BenefitDto>();
}
