using AuthApi.Domain.Entities;
using AuthApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Data.Context
{
    public class GlobalContext : DbContext,IUnitOfWork
    {
        public GlobalContext(DbContextOptions<GlobalContext> options) : base(options)
        {

        }
        public DbSet<Usuario>? Usuarios { get; set; }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                         .SelectMany(e => e.GetProperties()
                             .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GlobalContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
