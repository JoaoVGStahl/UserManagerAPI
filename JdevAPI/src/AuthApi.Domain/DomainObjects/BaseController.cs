using AuthApi.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AuthApi.Domain.DomainObjects
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificacaoService _notificationService;

        protected MainController(INotificacaoService notificationService)
        {
            _notificationService = notificationService;
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (_notificationService.ObterNotificacoes().Any())
                return BadRequest(_notificationService.ObterNotificacoes().Select(x => x.Mensagem));

            if (_notificationService.ObterValidationFailures().Any())
                return BadRequest(_notificationService.ObterValidationFailures().Select(x => new { x.PropertyName, x.ErrorMessage }));

            return Ok(result);
        }

        protected ActionResult CustomResponse(ModelStateDictionary dictionary)
        {
            if(dictionary.ErrorCount > 0)
            {
                foreach (var erro in dictionary.Values.SelectMany(ex => ex.Errors))
                {
                    _notificationService.Adicionar(new Notificacao(
                        erro.Exception == null
                        ? erro.ErrorMessage
                        : erro.Exception.Message));
                }
            }
            return CustomResponse();
        }
    }
}
