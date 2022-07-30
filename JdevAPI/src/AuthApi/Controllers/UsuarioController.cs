using AuthApi.Domain.DomainObjects;
using AuthApi.Domain.Entities;
using AuthApi.Domain.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : MainController
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioService usuarioService, INotificacaoService notificacaoService, IMapper mapper) : base(notificacaoService)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet("ObterUsuarioPorId/{usuarioId::guid}")]
        public async Task<IActionResult> ObterUsuarioPorId(Guid usuarioId)
        {
            return CustomResponse(await _usuarioService.ObterUsuarioPorId(usuarioId));
        }

        [HttpGet("ObterTodos")]
        public async Task<IActionResult> ObterTodos()
        {
            return CustomResponse(await _usuarioService.ObterTodosUsuarios());
        }

        [HttpPost("Adicionar")]
        public async Task<IActionResult> AdicionarUsuario([FromBody] AdicionarUsuarioDTO novoUsuarioDTO)
        {
            if (novoUsuarioDTO.Senha != novoUsuarioDTO.ConfirmarSenha)
            {
                return CustomResponse("As Senha são diferentes!");
            } 
            return CustomResponse(await _usuarioService.AdicionarUsuario(_mapper.Map<Usuario>(novoUsuarioDTO)));
        }
    }
}
