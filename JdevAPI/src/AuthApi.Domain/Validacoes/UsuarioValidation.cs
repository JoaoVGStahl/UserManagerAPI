using AuthApi.Domain.Entities;
using FluentValidation;

namespace AuthApi.Domain.Validacoes
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(r => r.Nome)
                .NotEmpty().WithMessage("O Nome não pode ser vazio!")
                .MaximumLength(64).WithMessage("Nome pode ter no máximo 64 caracteres");

            RuleFor(r => r.Senha)
                .NotEmpty().WithMessage("Senha não pode ser vazio!")
                .MaximumLength(64).WithMessage("Senha pode ter no máximo 64 caracteres");

            RuleFor(r => r.Email)
                .EmailAddress().WithMessage("Email Inválido")
                .MaximumLength(64).WithMessage("Email pode ter no máximo 100 caracteres");
        }
    }
}
