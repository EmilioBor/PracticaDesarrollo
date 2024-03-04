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
    public class DireccionService : IDireccionService
    {
        private readonly BancoG4Context _context;
        public DireccionService(BancoG4Context bancoG4Context)
        {
            _context = bancoG4Context;
        }
        public async Task<IEnumerable<DireccionDTOOut>> GetAll()
        {
            return await _context.Direccion.Select( c => new DireccionDTOOut()
            {
                Calle = c.Calle,
                Departamento = c.Departamento,
                Idlocalidad = c.Idlocalidad,
                Numero = c.Numero
            }).ToListAsync();
        }
        public async Task<Direccion?> GetId(int id)
        {
            var direccion = await _context.Direccion
                .Where(c => c.Id == id)
                .SingleOrDefaultAsync();
            return direccion;
        }
        public async Task<Direccion> Create(DireccionDTOIn direccionDTO)
        {
            var direccion = new Direccion();
            direccion.Calle = direccionDTO.Calle;
            direccion.Departamento = direccionDTO.Departamento;
            direccion.Idlocalidad = direccionDTO.Idlocalidad;
            direccion.Numero = direccionDTO.Numero;

            _context.Add(direccion);
            await _context.SaveChangesAsync();
            return direccion;
        }
        public async Task Update(int id, DireccionDTOIn direccionDTO)
        {
            var existe = await GetId(id);
            if (existe is not null)
            {
                existe.Calle = direccionDTO.Calle;
                existe.Departamento = direccionDTO.Departamento;
                existe.Numero = direccionDTO.Numero;
                existe.Idlocalidad = direccionDTO.Idlocalidad;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var existe = await GetId(id);
            if (existe is not null)
            {
                _context.Direccion.Remove(existe);
                await _context.SaveChangesAsync();
            }
        }
    }
}
