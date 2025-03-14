using FluentValidation;

namespace Client.Management.App.Application.Auth.v1.Commands.GenerateAccessToken;

public class GenerateAccessTokenCommandValidator : AbstractValidator<GenerateAccessTokenCommand>
{
    public GenerateAccessTokenCommandValidator()
    {
        RuleFor(p => p.Username).NotEmpty().WithMessage("O nome de usuário não pode ser vazio.");
        RuleFor(p => p.Password).NotEmpty().WithMessage("A senha não pode ser vazia.");
    }
}
