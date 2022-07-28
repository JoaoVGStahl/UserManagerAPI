using AuthApi.Domain.DomainObjects;
using AuthApi.Domain.Entities;
using AuthApi.Domain.Interfaces.Services;
using FluentValidation;
using FluentValidation.Results;

namespace AuthApi.Domain.Services
{
    public class BaseService
    {
        private INotificacaoService _notificacaoService;

        public BaseService(INotificacaoService notificacaoService)
        {
            _notificacaoService = notificacaoService;
        }

        protected bool Validar<TV, TE>(TV tValidacao, TE tEntidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = tValidacao.Validate(tEntidade);

            if (validator.IsValid)
                return true;

            Notificar(validator);
            return false;
        }

        protected void Notificar(string mensagem)
        {
            _notificacaoService.Adicionar(new Notificacao(mensagem));
        }

        protected void Notificar(ValidationResult validaResult)
        {
            validaResult.Errors.ToList().ForEach(e => _notificacaoService.Adicionar(e));
        }

        protected void Notificar(string prop, string mensagem)
        {
            _notificacaoService.Adicionar(new ValidationFailure(prop, mensagem));
        }
    }
}
