using Client.Management.App.Api.Models.v1;
using Client.Management.App.Application.Dtos.Client.v1;
using MediatR;

namespace Client.Management.App.Application.Client.v1.Queries.ListBenefitsByCpf;

public record ListBenefitsByCpfQuery : IRequest<Response<ClientDataDto>>
{
    public string? DocumentNumber { get; set; }
    public string? Token { get; set; }
}
