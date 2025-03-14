using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Client.Management.App.Api.Controllers.v1
{
    [Route("api/v1/inss")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("consulta-beneficios")]
        public Task<IActionResult> ListBenefits()
        {
            throw new NotImplementedException();
        }
    }
}
