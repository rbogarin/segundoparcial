using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    [Table("factura")]
    public class FacturaModel
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nro_factura")]
        public string NroFactura { get; set; }
        [Column("fecha_hora")]
        public DateTime FechaHora { get; set; }
        [Column("total")]
        public double Total { get; set; }
        [Column("total_iva5")]
        public double TotalIva5 { get; set; }
        [Column("total_iva10")]
        public double TotalIva10 { get; set; }
        [Column("total_iva")]
        public double TotalIva { get; set; }
        [Column("total_letras")]
        public string TotalLetras { get; set; }
        [Column("sucursal")]
        public string? Sucursal { get; set; }
        [Column("id_cliente")]
        public int IdCliente { get; set; }
        public ClienteModel? Cliente { get; set; }

    }
}
