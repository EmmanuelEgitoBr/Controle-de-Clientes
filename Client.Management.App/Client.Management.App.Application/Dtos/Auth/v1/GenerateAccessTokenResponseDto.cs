using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Client.Management.App.Application.Dtos.Auth.v1;

public class GenerateAccessTokenResponseDto
{
    public bool Success { get; set; }
    public DataDto? Data { get; set; }
}
