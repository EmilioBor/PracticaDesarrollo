using Data.Models;
using DTOs.request;
using DTOs.response;
using Microsoft.EntityFrameworkCore;
using Services.Interface;


namespace Services
{
    public class ClienteService : IClienteService
    {
        private readonly BancoG4Context _Context;
        public ClienteService(BancoG4Context bancoG4Context)
        {
            _Context = bancoG4Context;
        }

        public async Task<IEnumerable<ClienteDTOOut>> GetAll()
        {
            return await (_Context.Cliente.Select( c => new ClienteDTOOut
            {
                RazonSocial = c.RazonSocial,
                Cuil = c.Cuil,
                Alta = c.Alta,
                DireccionId = c.DireccionId
            }).ToListAsync());
        }

        public async Task<ClienteDTOOut?> GetById(int id)
        {
            return await _Context.Cliente.Where(c => c.Id == id).Select(c => new ClienteDTOOut
            {
                RazonSocial = c.RazonSocial,
                Cuil = c.Cuil,
                Alta = c.Alta,
                DireccionId= c.DireccionId
            }).SingleOrDefaultAsync();

        }

        public async Task<Cliente> Create(ClienteDTOIn nuevoclienteDTO)
        {
            var nuevocliente = new Cliente();

            nuevocliente.Id = nuevoclienteDTO.Id;
            nuevocliente.RazonSocial = nuevoclienteDTO.RazonSocial;
            nuevocliente.Cuil = nuevoclienteDTO.Cuil;
            nuevocliente.Alta = nuevoclienteDTO.Alta;
            nuevocliente.DireccionId = nuevoclienteDTO.DireccionId;


            _Context.Cliente.Add(nuevocliente);
            await _Context.SaveChangesAsync();

            return nuevocliente;
        }
        public async Task Update(int id, ClienteDTOIn cliente)
        {
            var existeCliente = await GetById(id);

            if (existeCliente is not null)
            {
                existeCliente.RazonSocial = cliente.RazonSocial;
                existeCliente.Cuil = cliente.Cuil;
                existeCliente.Alta = cliente.Alta;
                existeCliente.DireccionId = cliente.DireccionId;
                //existeCliente.Direccion = cliente.Direccion;

                await _Context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var existeCliente = await GetById(id);

            if (existeCliente is not null)
            {
                _Context.Remove(existeCliente);
                await _Context.SaveChangesAsync();

            }
        }
        
    }
}
