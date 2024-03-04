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
    public class PaisService : IPaisService
    {
        private readonly BancoG4Context _context;
        public PaisService(BancoG4Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PaisDTOOut>> GetAll()
        {
            return await _context.Pais.Select(p => new PaisDTOOut
            {
                Nombre = p.Nombre
            }).ToListAsync();
        }
        public async Task<Pais?> GetxId(int id)
        {
            return await _context.Pais
                .Where(p => p.Id == id)
                .Select(p => new Pais
                {
                    Id = p.Id,
                    Nombre = p.Nombre
                }).SingleOrDefaultAsync();
        }
        public async Task<Pais> Create(Pais paisDTOIn)
        {
            var nuevoPais = new Pais();
            nuevoPais.Nombre = paisDTOIn.Nombre;

            _context.Pais.Add(nuevoPais);
            await _context.SaveChangesAsync();
            return nuevoPais;
        }
        public async Task<Pais> Update(int id, PaisDTOIn pais)
        {
            var existePais = await GetxId(id);
            if (existePais is not null)
            {
               existePais.Nombre = pais.Nombre;

                
                await _context.SaveChangesAsync();
                return existePais;
            }
            else
            {
                return existePais;
            }
        }
        public async Task Delete(int id)
        {
            var existe = await GetxId(id);
            if ( existe is not null)
            {
                _context.Pais.Remove(existe);
                await _context.SaveChangesAsync();
            }
        }
    }
}
