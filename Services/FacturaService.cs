using Repository.Contexts;
using Repository.Models;
using Repository.Repositories;
using System.Text.RegularExpressions;

namespace Service
{
    public class FacturaService
    {
        private FacturaRepository facturaRepository;
        public FacturaService(ContextoAplicacionDB contexto)
        {
            facturaRepository = new FacturaRepository(contexto);
        }

        public string insertarFactura(FacturaModel factura)
        {
            return validarDatosFactura(factura) ? facturaRepository.add(factura) : throw new Exception("Error en la validación");
        }

        public string modificarFactura(FacturaModel factura, int id)
        {
            if (facturaRepository.get(id) != null)
                return validarDatosFactura(factura) ?
                  facturaRepository.update(factura, id) :
                    throw new Exception("Error en la validación");
            else
                return "No se encontraron los datos de esta factura";
        }
        public string remove(int id)
        {
            return facturaRepository.remove(id);
        }

        public FacturaModel consultarFactura(int id)
        {
            return facturaRepository.get(id);
        }

        public IEnumerable<FacturaModel> list()
        {
            return facturaRepository.list();
        }

        private bool validarDatosFactura(FacturaModel factura)
        {
            if (!Regex.IsMatch(factura.NroFactura, @"^\d{3}-\d{3}-\d{6}$"))
            {
                return false;
            }

            if (!Regex.IsMatch(factura.Total.ToString(), @"^\d+(\.\d+)?$"))
            {
                return false;
            }

            if (!Regex.IsMatch(factura.TotalIva5.ToString(), @"^\d+(\.\d+)?$"))
            {
                return false;
            }

            if (!Regex.IsMatch(factura.TotalIva10.ToString(), @"^\d+(\.\d+)?$"))
            {
                return false;
            }

            if (!Regex.IsMatch(factura.TotalIva.ToString(), @"^\d+(\.\d+)?$"))
            {
                return false;
            }

            if(factura.TotalLetras.Length < 6)
            {
                return false;
            }
            return true;
        }
    }
}
