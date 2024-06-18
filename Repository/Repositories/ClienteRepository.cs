
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Repositories
{
    public class ClienteRepository : ICliente
    {
        private readonly ContextoAplicacionDB _contexto;

        public ClienteRepository(ContextoAplicacionDB contexto)
        {
            _contexto = contexto;
        }
        public string add(ClienteModel cliente)
        {
            _contexto.Clientes.Add(cliente);
            int resultado = _contexto.SaveChanges();
            return resultado > 0 ? "Se inserto correctamente..." : "No se pudo insertar...";
        }

        public ClienteModel get(int id)
        {
            var cliente = _contexto.Clientes.Include(cliente => cliente.Facturas).FirstOrDefault(cliente => cliente.Id == id);
            if (cliente == null)
            {
                throw new Exception("No se encontró el cliente con el id solicitado");
            }

            var clienteConFacturas = new ClienteModel()
            {
                Id = cliente.Id,
                IdBanco = cliente.IdBanco,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Documento = cliente.Documento,
                Direccion = cliente.Direccion,
                Mail = cliente.Mail,
                Celular = cliente.Celular,
                Estado = cliente.Estado,
                Facturas = cliente.Facturas.Select(factura => new FacturaModel
                {
                    Id = factura.Id,
                    NroFactura = factura.NroFactura,
                    FechaHora = factura.FechaHora,
                    Total = factura.Total,
                    TotalIva5 = factura.TotalIva5,
                    TotalIva10 = factura.TotalIva10,
                    TotalIva = factura.TotalIva,
                    TotalLetras = factura.TotalLetras,
                    Sucursal = factura.Sucursal,
                }).ToList()
            };

            return clienteConFacturas;

        }

        public IEnumerable<ClienteModel> list()
        {
            var clientes = _contexto.Clientes.Include(cliente => cliente.Facturas).ToList();
            if (clientes == null)
            {
                throw new Exception("No se encontró el cliente con el id solicitado");
            }

            var clientesConFacturas = new List<ClienteModel>();
            foreach (var cliente in clientes)
            {
                var clienteConFacturas = new ClienteModel()
                {
                    Id = cliente.Id,
                    IdBanco = cliente.IdBanco,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Documento = cliente.Documento,
                    Direccion = cliente.Direccion,
                    Mail = cliente.Mail,
                    Celular = cliente.Celular,
                    Estado = cliente.Estado,
                    Facturas = cliente.Facturas.Select(factura => new FacturaModel
                    {
                        Id = factura.Id,
                        NroFactura = factura.NroFactura,
                        FechaHora = factura.FechaHora,
                        Total = factura.Total,
                        TotalIva5 = factura.TotalIva5,
                        TotalIva10 = factura.TotalIva10,
                        TotalIva = factura.TotalIva,
                        TotalLetras = factura.TotalLetras,
                        Sucursal = factura.Sucursal,
                    }).ToList()
                };
                clientesConFacturas.Add(clienteConFacturas);
            }

            return clientesConFacturas;
        }

        public string remove(int id)
        {
            var cliente = _contexto.Clientes.Find(id);
            if (cliente == null)
            {
                throw new Exception("El cliente que se intenta eliminar no existe");
            }
            _contexto.Clientes.Remove(cliente);
            int resultado = _contexto.SaveChanges();
            return resultado > 0 ? "Se eliminó correctamente el registro..." : "No se pudo eliminar...";
        }

        public string update(ClienteModel cliente, int id)
        {
            var resultado = _contexto.Clientes.Find(id);

            if (resultado == null)
            {
                throw new Exception("No se pudo encontrar el cliente con id " + id);
            }

            resultado.Nombre = cliente.Nombre;
            resultado.Apellido = cliente.Apellido;
            resultado.Documento = cliente.Documento;
            resultado.Direccion = cliente.Direccion;
            resultado.Mail = cliente.Mail;
            resultado.Celular = cliente.Celular;
            resultado.Estado = cliente.Estado;
            resultado.IdBanco = cliente.IdBanco;

            int update = _contexto.SaveChanges();

            return update > 0 ? "Se modificaron los datos correctamente..." : "No se pudo modificar...";
        }
    }
}
