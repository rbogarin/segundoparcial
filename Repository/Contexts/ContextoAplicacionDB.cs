using Microsoft.EntityFrameworkCore;
using Repository.Configurations;
using Repository.Models;

namespace Repository.Contexts
{
    public class ContextoAplicacionDB : DbContext
    {
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<FacturaModel> Facturas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new FacturaConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public ContextoAplicacionDB(DbContextOptions<ContextoAplicacionDB> options) : base(options)
        {
        }
    }
}
