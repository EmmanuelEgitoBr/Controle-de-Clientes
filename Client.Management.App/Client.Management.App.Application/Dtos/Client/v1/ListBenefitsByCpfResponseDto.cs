namespace Client.Management.App.Application.Dtos.Client.v1;

public record ListBenefitsByCpfResponseDto
{
    public bool Success { get; set; }
    public ClientDataDto? Data { get; set; }
}
