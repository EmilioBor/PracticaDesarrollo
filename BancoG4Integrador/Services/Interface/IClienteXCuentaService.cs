using Data.Models;
using DTOs.request;
using DTOs.response;

namespace Services.Interface
{
    public interface IClienteXCuentaService
    {
        Task<IEnumerable<ClienteXCuentaDTOOut>> GetAll();
        //Task<ClienteXCuentaDTOOut?> GetIdDto(int id);
        Task<ClienteXcuenta> Create(ClienteXCuentaDTOIn clienteXCuentaDTO);
        Task Actualizando(int id, ClienteXCuentaDTOIn clienteXCuentaDTO);
        Task Eliminando(int id);
        Task<ClienteXcuenta?> GetId(int id);
    }
}