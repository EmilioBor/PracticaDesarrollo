using Core.Request;
using Core.Response;
using Data.Models;

namespace Services.Interface
{
    public interface IAutosService
    {
        Task<IEnumerable<AutosDtoOut>> GetAll();
        //Task<AutosDtoOut?> GetById(int id);
        Task<Autos?> GetById(int id);
        Task<AutosDtoOut?> GetId(int id);
        Task<Autos> Create(AutosDtoIn autos);
        Task Update(int id, AutosDtoIn autos);
        Task Delete(int id);
    }
}