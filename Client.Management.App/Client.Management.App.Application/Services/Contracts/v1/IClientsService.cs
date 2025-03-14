using Client.Management.App.Application.Dtos.Client.v1;
using Refit;

namespace Client.Management.App.Application.Services.Contracts.v1;

[Headers("Content-Type: application/json", "Accept: application/json")]
public interface IClientsService
{
    [Get("/api/v1/inss/consulta-beneficios?cpf={cpf}")]
    Task<HttpResponseMessage> ListBenefitsByCpfAsync([Query] ListBenefitsByCpfRequestDto authLoginRequestDto);

}
