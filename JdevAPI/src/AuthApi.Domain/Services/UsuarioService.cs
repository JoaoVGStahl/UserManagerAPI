using AuthApi.Domain.Entities;
using AuthApi.Domain.Interfaces.Repository;
using AuthApi.Domain.Interfaces.Services;
using AuthApi.Domain.Notificacoes;

namespace AuthApi.Domain.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private IUsuarioRepository _repository { get; set; }
        public UsuarioService(IUsuarioRepository repository, INotificacaoService notificacaoService) : base(notificacaoService)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public async Task<Usuario> AdicionarUsuario(Usuario usuario)
        {
            var usuarioExiste = await _repository.ObterUsuarioPorEmail(usuario.Email);

            //TODO HashMd5

            if (usuarioExiste != null)
            {
                Notificar(UsuarioNotificacoes.EmailJaCadastrado);
                return null;
            }

            usuario.DataCadastro = DateTime.Now;

            _repository.AdicionarUsario(usuario);

            if (!await _repository.UnitOfWork.Commit())
            {
                Notificar(UsuarioNotificacoes.ErroAdicionar);
                return null;
            }

            return usuario;
        }

        public async Task<Usuario> ApagarUsuario(Usuario usuario)
        {
            var usuarioBanco = await _repository.ObterUsuarioPorId(usuario.Id);

            if (usuarioBanco == null)
            {
                Notificar(UsuarioNotificacoes.UsuarioNaoEncontrado);
                return null;
            }

            usuario.Apagado = true;

            _repository.EditarUsuario(usuario);

            if (!await _repository.UnitOfWork.Commit())
            {
                Notificar(UsuarioNotificacoes.ErroApagar);
                return null;
            }

            return usuario;
        }

        public async Task<Usuario> EditarUsuario(Usuario usuario)
        {
            var antigoUsuario = await _repository.ObterUsuarioPorId(usuario.Id);

            if (antigoUsuario == null)
            {
                Notificar(UsuarioNotificacoes.UsuarioNaoEncontrado);
                return null;
            }

            antigoUsuario.Nome = usuario.Nome;
            antigoUsuario.Email = usuario.Email;

            _repository.EditarUsuario(usuario);

            if (!await _repository.UnitOfWork.Commit())
            {
                Notificar(UsuarioNotificacoes.ErroEditar);
                return null;
            }

            return usuario;
        }

        public async Task<List<Usuario>> ObterTodosUsuarios()
        {
            return await _repository.ObterTodosUsuarios();
        }

        public async Task<Usuario> ObterUsuarioPorEmail(string email)
        {
            return await _repository.ObterUsuarioPorEmail(email);
        }

        public async Task<Usuario> ObterUsuarioPorId(Guid usuarioId)
        {
            var usuario = await _repository.ObterUsuarioPorId(usuarioId);

            if (usuario == null)
            {
                Notificar(UsuarioNotificacoes.UsuarioNaoEncontrado);
                return null;
            }

            return usuario;
        }

        public async Task<Usuario> EfetuarLogin(Usuario usuario)
        {
            var usuarioBanco = await _repository.ObterUsuarioPorEmail(usuario.Email);

            if (usuarioBanco == null)
            {
                Notificar(UsuarioNotificacoes.UsuarioNaoEncontrado);
                return null;
            }

            if (usuario.Senha != usuarioBanco.Senha)
            {
                Notificar(UsuarioNotificacoes.SenhaIncorreta);
                return null;
            }

            return usuarioBanco;
        }
    }
}
