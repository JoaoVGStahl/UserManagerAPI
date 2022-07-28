using AuthApi.Domain.Entities;

namespace AuthApi.Domain.Interfaces.Services
{
    public interface IUsuarioService : IDisposable
    {
        Task<Usuario> AdicionarUsuario(Usuario usuario);
        Task<Usuario> EditarUsuario(Usuario usuario);
        Task<Usuario> ApagarUsuario(Usuario usuario);
        Task<List<Usuario>> ObterTodosUsuarios();
        Task<Usuario> ObterUsuarioPorEmail(string email);
        Task<Usuario> ObterUsuarioPorId(Guid usuarioId);
        Task<Usuario> EfetuarLogin(Usuario usuario);
    }
}
