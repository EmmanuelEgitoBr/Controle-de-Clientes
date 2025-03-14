using Client.Management.App.Api.Models.v1;
using Client.Management.App.Application.Client.v1.Queries.ListBenefitsByCpf;
using Client.Management.App.Application.Dtos.Client.v1;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Management.App.Api.Controllers.v1
{
    [Route("api/v1/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("beneficios-por-cpf")]
        [ProducesResponseType(typeof(Response<ClientDataDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ClientDataDto>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<ClientDataDto>), StatusCodes.Status404NotFound)]
        public Task<Response<ClientDataDto>> ListBenefits([FromQuery] string cpf, 
            [FromHeader(Name = "Authorization")] string? authorizationHeader)
        {
            var token = authorizationHeader!["Bearer ".Length..];

            var query = new ListBenefitsByCpfQuery
            {
                DocumentNumber = cpf,
                Token = token
            };
            
            return _mediator.Send(query);
        }
    }
}
