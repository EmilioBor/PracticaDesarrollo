using Data.Models;
using DTOs.request;
using DTOs.response;

namespace Services.Interface
{
    public interface IBancoService
    {
        Task<Banco> Create(BancoDtoIn bancoDtoIn);
        //Task Update(int id, BancoDtoIn bancoDtoIn);
        Task<Banco?> GetByID(int id);
        Task<IEnumerable<BancoDtoOut>> GetAll();
        Task Update(int id, BancoDtoIn bancoDtoIn);
        Task Delete(int id);


    }
}