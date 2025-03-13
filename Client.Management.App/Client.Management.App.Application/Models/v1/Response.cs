using System.Net;

namespace Client.Management.App.Api.Models.v1;

public record Response<T> where T : class
{
    public HttpStatusCode StatusCode { get; set; }
    public T? Content { get; set; }
    public string? Notifications { get; set; }
}