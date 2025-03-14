using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Client.Management.App.Application.Dtos.Client.v1;

public record ListBenefitsByCpfResponseDto
{
    public bool Success { get; set; }
    public DataDto? Data { get; set; }
}
