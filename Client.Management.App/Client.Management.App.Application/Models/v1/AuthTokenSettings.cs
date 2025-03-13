namespace Client.Management.App.Application.Models.v1;

public class AuthTokenSettings
{
    public string? ValidAudience { get; set; }
    public string? ValidIssuer { get; set; }
    public string? SecretKey {  get; set; }
    public int TokenValidityInMinutes { get; set; }
}
