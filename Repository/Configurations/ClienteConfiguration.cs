using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Models;

namespace Repository.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasMany(p => p.Facturas)
                .WithOne(c => c.Cliente)
                .HasForeignKey(c => c.IdCliente);
        }
    }
}
