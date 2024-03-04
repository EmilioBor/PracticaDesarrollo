using Core.Request;
using Core.Response;
using Data.Models;

namespace Services.Interface
{
    public interface ICocheraService
    {
        Task<IEnumerable<CocheraDtoOut>> GetAll();
        //Task<CocheraDtoOut?> GetById(int id);
        Task<Cocheras?> GetId(int id);
        Task<Cocheras> Create(CocheraDtoIn cochera);
        Task Update(int id, CocheraDtoIn cochera);
        Task Delete(int id);
    }
}