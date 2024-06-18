using Repository.Models;

namespace Repository.Interfaces
{
    public interface IFactura
    {
        string add(FacturaModel factura);
        string update(FacturaModel factura, int id);
        string remove(int id);
        FacturaModel get(int id);
        IEnumerable<FacturaModel> list();
    }
}
