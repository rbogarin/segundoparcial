using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{

    [Table("cliente")]
    public class ClienteModel
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("id_banco")]
        public int? IdBanco { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("apellido")]
        public string Apellido { get; set; }
        [Column("documento")]
        public string Documento { get; set; }
        [Column("direccion")]
        public string? Direccion { get; set; }
        [Column("mail")]
        public string? Mail { get; set; }
        [Column("celular")]
        public string? Celular { get; set; }
        [Column("estado")]
        public string? Estado { get; set; }
        public ICollection<FacturaModel>? Facturas { get; set; }
    }
}

