using Data.Models;
using DTOs.request;
using DTOs.response;

namespace Services.Interface
{
    public interface ILocalidadService
    {
        Task<IEnumerable<LocalidadDTOOut>> GetAll();
        Task<Localidad?> GetID(int id);
        Task<Localidad> Create(LocalidadDTOIn localidad);
        Task Update(int id, LocalidadDTOIn localidad);
        Task Delete(int id);
    }
}