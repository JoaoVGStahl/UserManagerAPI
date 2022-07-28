using AuthApi.Domain.Entities;

namespace AuthApi.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        void AdicionarUsario(Usuario usuario);
        void EditarUsuario(Usuario usuario);
        Task<Usuario> ObterUsuarioPorId(Guid id);
        Task<List<Usuario>> ObterTodosUsuarios();
        Task<Usuario> ObterUsuarioPorEmail(string email);
    }
}
