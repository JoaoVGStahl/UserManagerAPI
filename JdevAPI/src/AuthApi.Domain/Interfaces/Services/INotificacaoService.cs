using AuthApi.Domain.DomainObjects;
using FluentValidation.Results;

namespace AuthApi.Domain.Interfaces.Services
{
    public interface INotificacaoService
    {
        void Adicionar(Notificacao notificacao);
        void Adicionar(ValidationFailure validationFailure);
        List<Notificacao> ObterNotificacoes();
        List<ValidationFailure> ObterValidationFailures();
        void Clear();
    }
}
