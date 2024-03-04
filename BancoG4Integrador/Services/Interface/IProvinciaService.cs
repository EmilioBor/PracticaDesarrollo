using Data.Models;
using DTOs.request;
using DTOs.response;

namespace Services.Interface
{
    public interface IProvinciaService
    {
        Task<IEnumerable<Provincia>> GetAll();
        Task<Provincia?> GetxId(int id);
        Task<Provincia> Create(ProvinciumDTOIn paisDTOIn);
        Task Update(int id, ProvinciumDTOIn pais);
        Task Delete(int id);
    }
}