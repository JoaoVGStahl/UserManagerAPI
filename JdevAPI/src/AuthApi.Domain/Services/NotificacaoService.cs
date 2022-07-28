using AuthApi.Domain.DomainObjects;
using AuthApi.Domain.Interfaces.Services;
using FluentValidation.Results;

namespace AuthApi.Domain.Services
{
    public class NotificacaoService : INotificacaoService
    {
        private List<Notificacao> _notificacoes;
        private List<ValidationFailure> _validationFailures;
        public NotificacaoService()
        {
            Clear();
        }

        public void Adicionar(ValidationFailure validationFailure) => _validationFailures.Add(validationFailure);

        public void Adicionar(Notificacao notificacao)=> _notificacoes.Add(notificacao);

        public List<Notificacao> ObterNotificacoes() => _notificacoes;

        public List<ValidationFailure> ObterValidationFailures() => _validationFailures;

        public void Clear()
        {
            _notificacoes = new();
            _validationFailures = new();
        }
    }
}
