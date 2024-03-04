using Data.Models;
using DTOs.request;
using DTOs.response;

namespace Services.Interface
{
    public interface ITipoCuentaService
    {
        Task<IEnumerable<TipoCuentaDTOOut>> GetAll();
        Task<TipoCuenta?> GetxId(int id);
        Task<TipoCuenta> Create(TipoCuentaDTOIn tipoCuenta);
        Task Update(int id, TipoCuentaDTOIn tipoCuenta);
        Task Delete(int id);
    }
}