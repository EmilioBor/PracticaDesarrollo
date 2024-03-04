using Data.Models;
using DTOs.request;
using DTOs.response;

namespace Services.Interface
{
    public interface IPaisService
    {
        Task<IEnumerable<PaisDTOOut>> GetAll();
        Task<Pais?> GetxId(int id);
        Task<Pais> Create(Pais paisDTOIn);
        Task<Pais> Update(int id, PaisDTOIn pais);
        Task Delete(int id);
    }
}