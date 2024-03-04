using Data.Models;
using DTOs.request;
using DTOs.response;

namespace Services.Interface
{
    public interface ITipoTransaccionService
    {
        Task<IEnumerable<TipoTransaccionDTOOut>> GetAll();
        Task<TipoTransaccion?> GetxId(int id);
        Task<TipoTransaccion> Create(TipoTransaccionDTOIn tipoTransaccion);
        Task Update(int id, TipoTransaccionDTOIn tipoTransaccion);
        Task Delete(int id);
    }
}