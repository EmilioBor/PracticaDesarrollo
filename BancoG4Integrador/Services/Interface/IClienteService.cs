using Data.Models;
using DTOs.request;
using DTOs.response;

namespace Services.Interface
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTOOut>> GetAll();
        Task<ClienteDTOOut?> GetById(int id);
        Task<Cliente> Create(ClienteDTOIn nuevoclienteDTO);
        Task Update(int id, ClienteDTOIn cliente);
        Task Delete(int id);
    }
}