using Client.Management.App.Api.Models.v1;
using Client.Management.App.Application.Dtos.Client.v1;
using Client.Management.App.Application.Resources.v1;
using Client.Management.App.Application.Services.Contracts.v1;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace Client.Management.App.Application.Client.v1.Queries.ListBenefitsByCpf;

public class ListBenefitsByCpfQueryHandler : IRequestHandler<ListBenefitsByCpfQuery, Response<ClientDataDto>>
{
    private readonly ILogger<ListBenefitsByCpfQueryHandler> _logger;
    private readonly IClientsService _clientsService;

    public ListBenefitsByCpfQueryHandler(ILogger<ListBenefitsByCpfQueryHandler> logger,
                                        IClientsService clientsService)
    {
        _logger = logger;
        _clientsService = clientsService;
    }

    public async Task<Response<ClientDataDto>> Handle(ListBenefitsByCpfQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(LogTemplate.StartHandler, nameof(ListBenefitsByCpfQueryHandler));

        var requestDto = new ListBenefitsByCpfRequestDto
        {
            DocumentNumber = request.DocumentNumber
        };

        var result = await _clientsService.ListBenefitsByCpfAsync(request.Token!, requestDto);

        if (!result.IsSuccessStatusCode)
        {
            _logger.LogError(LogTemplate.EndHandler, Message.ErrorGetBenefitsInfo);

            return new Response<ClientDataDto>
            {
                StatusCode = result.StatusCode,
                Notification = Message.ErrorGetBenefitsInfo
            };
        }

        var reponse = await result.Content.ReadFromJsonAsync<ListBenefitsByCpfResponseDto>(); 

        _logger.LogInformation(LogTemplate.EndHandler, nameof(ListBenefitsByCpfQueryHandler));

        return new Response<ClientDataDto>
        {
            Content = reponse!.Data,
            StatusCode = result.StatusCode
        };
    }
}
