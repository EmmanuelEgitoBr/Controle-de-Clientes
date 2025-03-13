using Client.Management.App.Api.Services.Dtos.v1;
using FluentValidation;

namespace Client.Management.App.Application.Services.Token.Validators.v1;

public class GenerateTokenCommandValidator : AbstractValidator<LoginRequestDto>
{
    public GenerateTokenCommandValidator()
    {
        RuleFor(p => p.Username).NotEmpty().WithMessage("O usuário não pode ser vazio.");
        RuleFor(p => p.Password).NotEmpty().WithMessage("A senha não pode ser vazia.");
    }
}
