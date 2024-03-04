using Data.Models;
using DTOs.request;
using DTOs.response;

namespace Services
{
    public interface ITransaccionesService
    {
        Task<IEnumerable<TransaccionDTOOut>> GetAll();
        Task<Transaccion?> GetxId(int id);
        Task<Transaccion> Create(TransaccionDTOIn transaccion);
        Task Update(int id, TransaccionDTOIn transaccion);
        Task Delete(int id);
    }
}