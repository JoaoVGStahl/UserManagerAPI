using AuthApi.Data.Context;
using AuthApi.Domain.Entities;
using AuthApi.Domain.Interfaces;
using AuthApi.Domain.Interfaces.Repository;
using System.Data.Entity;

namespace AuthApi.Data.Repository
{
    internal class UsuarioRepository : IUsuarioRepository
    {
        public IUnitOfWork UnitOfWork => _context;
        private readonly GlobalContext _context;

        public UsuarioRepository(GlobalContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async void AdicionarUsario(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }

        public void EditarUsuario(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }

        public async Task<List<Usuario>> ObterTodosUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> ObterUsuarioPorEmail(string email)
        {
            return await _context.Usuarios.Where(p => p.Email == email).FirstOrDefaultAsync();
        }

        public async Task<Usuario> ObterUsuarioPorId(Guid id)
        {
            return await _context.Usuarios.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
    }
}
