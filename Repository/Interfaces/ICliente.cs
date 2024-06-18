using Repository.Models;

namespace Repository.Interfaces
{
    public interface ICliente
    {
        string add(ClienteModel cliente);
        string update(ClienteModel cliente, int id);
        string remove(int id);
        ClienteModel get(int id);
        IEnumerable<ClienteModel> list();
    }
}
