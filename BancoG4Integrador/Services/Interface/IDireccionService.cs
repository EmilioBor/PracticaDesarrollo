using Data.Models;
using DTOs.request;
using DTOs.response;

namespace Services.Interface
{
    public interface IDireccionService
    {
        Task<IEnumerable<DireccionDTOOut>> GetAll();
        Task<Direccion?> GetId(int id);
        Task<Direccion> Create(DireccionDTOIn direccionDTO);
        Task Update(int id, DireccionDTOIn direccionDTO);
        Task Delete(int id);
    }
}