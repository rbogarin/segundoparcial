
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Repositories
{
    public class FacturaRepository : IFactura
    {
        private readonly ContextoAplicacionDB _contexto;

        public FacturaRepository(ContextoAplicacionDB contexto)
        {
            _contexto = contexto;
        }
        public string add(FacturaModel factura)
        {
            _contexto.Facturas.Add(factura);
            int resultado = _contexto.SaveChanges();
            return resultado > 0 ? "Se inserto correctamente..." : "No se pudo insertar...";
        }

        public FacturaModel get(int id)
        {
            var factura = _contexto.Facturas
                .Include(factura => factura.Cliente)
                .Where(factura => factura.Id == id)
                .Select(f => new FacturaModel
                {
                    Id = f.Id,
                    NroFactura = f.NroFactura,
                    FechaHora = f.FechaHora,
                    Total = f.Total,
                    TotalIva5 = f.TotalIva5,
                    TotalIva10 = f.TotalIva10,
                    TotalIva = f.TotalIva,
                    TotalLetras = f.TotalLetras,
                    Sucursal = f.Sucursal,
                    IdCliente = f.IdCliente,
                    Cliente = new ClienteModel
                    {
                        Id = f.IdCliente,
                        Nombre = f.Cliente.Nombre,
                        Apellido = f.Cliente.Apellido,
                        Documento = f.Cliente.Documento,
                        Direccion = f.Cliente.Direccion,
                        Mail = f.Cliente.Mail,
                        Celular = f.Cliente.Celular,
                        IdBanco = f.Cliente.IdBanco,
                        Estado = f.Cliente.Estado
                    }
                })
                .FirstOrDefault();
            if (factura == null)
            {
                throw new Exception("No se encontró la factura con el id solicitado");
            }

            return factura;
        }

        public IEnumerable<FacturaModel> list()
        {
            return _contexto.Facturas
                .Include(factura => factura.Cliente)
                .Select(f => new FacturaModel
                {
                    Id = f.Id,
                    NroFactura = f.NroFactura,
                    FechaHora = f.FechaHora,
                    Total = f.Total,
                    TotalIva5 = f.TotalIva5,
                    TotalIva10 = f.TotalIva10,
                    TotalIva = f.TotalIva,
                    TotalLetras = f.TotalLetras,
                    Sucursal = f.Sucursal,
                    IdCliente = f.IdCliente,
                    Cliente = new ClienteModel
                    {
                        Id = f.IdCliente,
                        Nombre = f.Cliente.Nombre,
                        Apellido = f.Cliente.Apellido,
                        Documento = f.Cliente.Documento,
                        Direccion = f.Cliente.Direccion,
                        Mail = f.Cliente.Mail,
                        Celular = f.Cliente.Celular,
                        IdBanco = f.Cliente.IdBanco,
                        Estado = f.Cliente.Estado
                    }
                }).ToList();
        }

        public string remove(int id)
        {
            var factura = _contexto.Facturas.Find(id);
            if (factura == null)
            {
                throw new Exception("La factura que se intenta eliminar no existe");
            }
            _contexto.Facturas.Remove(factura);
            int resultado = _contexto.SaveChanges();
            return resultado > 0 ? "Se eliminó correctamente la factura..." : "No se pudo eliminar...";
        }

        public string update(FacturaModel factura, int id)
        {
            var resultado = _contexto.Facturas.Find(id);

            if (resultado == null)
            {
                throw new Exception("No se pudo encontrar la factura con id " + id);
            }

            resultado.NroFactura = factura.NroFactura;
            resultado.FechaHora = factura.FechaHora;
            resultado.Total = factura.Total;
            resultado.TotalIva5 = factura.TotalIva5;
            resultado.TotalIva10 = factura.TotalIva10;
            resultado.TotalIva = factura.TotalIva;
            resultado.TotalLetras = factura.TotalLetras;
            resultado.Sucursal = factura.Sucursal;
            resultado.IdCliente = factura.IdCliente;


            int update = _contexto.SaveChanges();

            return update > 0 ? "Se modificaron los datos correctamente..." : "No se pudo modificar...";
        }
    }
}
