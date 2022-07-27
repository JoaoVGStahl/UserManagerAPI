using AuthApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace AuthApi.Data.Context
{
    public class GlobalContext : DbContext
    {
        public DbSet<Usuario>? Usuarios { get; set; }

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
