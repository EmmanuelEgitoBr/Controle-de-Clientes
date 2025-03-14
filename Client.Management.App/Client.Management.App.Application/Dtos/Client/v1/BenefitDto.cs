using System.Text.Json.Serialization;

namespace Client.Management.App.Application.Dtos.Client.v1;

public record BenefitDto
{
    [JsonPropertyName("numero_beneficio")]
    public string BenefitNumber { get; set; }

    [JsonPropertyName("codigo_tipo_beneficio")]
    public string BenefitTypeCode { get; set; }
}
