using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Configurations
{
    public class FacturaConfiguration : IEntityTypeConfiguration<FacturaModel>
    {
        public void Configure(EntityTypeBuilder<FacturaModel> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
               .HasOne(factura => factura.Cliente)
               .WithMany(cliente => cliente.Facturas)
               .HasForeignKey(factura => factura.IdCliente);
        }
    }
}
