using Data.Models;
using DTOs.request;
using DTOs.response;

namespace Services.Interface
{
    public interface ICuentaService
    {
        Task<IEnumerable<CuentaDTOOut>> GetAll();
        Task<Cuenta?> GetId(int id);
        Task<Cuenta> Create(CuentaDTOIn cuentaDTO);
        Task Update(int id, CuentaDTOIn cuentaDTO);
        Task Delete(int id);
    }
}