using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using DTOs.request;
using DTOs.response;
using Microsoft.EntityFrameworkCore;
using Services.Interface;

namespace Services
{
    public class ClienteXCuentaService : IClienteXCuentaService
    {
        private readonly BancoG4Context _context;
        public ClienteXCuentaService(BancoG4Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ClienteXCuentaDTOOut>> GetAll()
        {
            return await _context.ClienteXcuenta.Select(c => new ClienteXCuentaDTOOut
            {
                Alta = c.Alta,
                ClienteId = c.ClienteId,
                CuentaId = c.ClienteId,
                Rol = c.Rol
            }).ToListAsync();
        }
        //public async Task<ClienteXCuentaDTOOut?> GetIdDto(int id)
        //{
        //    return await _context.ClienteXcuenta
        //        .Where(c => c.Id == id)
        //        .Select(c => new ClienteXCuentaDTOOut
        //    {
        //        Alta = c.Alta,
        //        ClienteId = c.ClienteId,
        //        CuentaId = c.CuentaId,
        //        Rol = c.Rol
        //    }).SingleOrDefaultAsync();
        //}
        public async Task<ClienteXcuenta> Create(ClienteXCuentaDTOIn clienteXCuentaDTO)
        {
            var nuevoClientexCuenta = new ClienteXcuenta();

            nuevoClientexCuenta.Alta = clienteXCuentaDTO.Alta;
            nuevoClientexCuenta.Rol = clienteXCuentaDTO.Rol;
            nuevoClientexCuenta.ClienteId = clienteXCuentaDTO.ClienteId;
            nuevoClientexCuenta.CuentaId = clienteXCuentaDTO.CuentaId;

            await _context.ClienteXcuenta.AddAsync(nuevoClientexCuenta);
            await _context.SaveChangesAsync();
            return nuevoClientexCuenta;

        }
        public async Task Actualizando(int id, ClienteXCuentaDTOIn clienteXCuentaDTO)
        {
            var existe = await GetId(id);
            if(existe is not null)
            {
                existe.Alta = clienteXCuentaDTO.Alta;
                existe.Rol = clienteXCuentaDTO.Rol;
                existe.ClienteId = clienteXCuentaDTO.ClienteId;
                existe.CuentaId = clienteXCuentaDTO.CuentaId;

                await _context.SaveChangesAsync();
            }
        }
        public async Task<ClienteXcuenta?> GetId(int id)
        {
            var existe = await _context.ClienteXcuenta
                .Where( c => c.Id == id)
                .SingleOrDefaultAsync();
            return existe;
        }
        public async Task Eliminando(int id)
        {
            var existe = await GetId(id);
            if (existe is not null)
            {
                _context.ClienteXcuenta.Remove(existe);
                await _context.SaveChangesAsync();
                
            }
        }
    }
}
