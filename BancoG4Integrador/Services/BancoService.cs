using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.request;
using System.Security.Principal;
using DTOs.response;
using Services.Interface;

namespace Services
{
    public class BancoService : IBancoService
    {
        private BancoG4Context _context;
        public BancoService(BancoG4Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BancoDtoOut>> GetAll()
        {
            return await _context.Banco.Select(b => new BancoDtoOut
            {
                
                Nombre = b.Nombre
            }).ToListAsync();
        }
        public async Task<Banco?> GetByID(int id)
        {
            return await _context.Banco.
                Where(a => a.Id == id).
                Select(a => new Banco
            {
                Id = a.Id,
                Nombre = a.Nombre
            }).SingleOrDefaultAsync();
        }

        public async Task<Banco> Create(BancoDtoIn bancoDtoIn)
        {
            var nuevoBanco = new Banco();

            
            nuevoBanco.Nombre = bancoDtoIn.Nombre;
            
            _context.Banco.Add(nuevoBanco);
            await _context.SaveChangesAsync();
            return nuevoBanco;
        }
        public async Task Update(int id, BancoDtoIn bancoDtoIn)
        {
            var existe = await GetByID(id);
            if (existe is not null)
            {
                existe.Nombre = bancoDtoIn.Nombre;

                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var existe = await GetByID(id);
            if (existe is not null)
            {
                _context.Banco.Remove(existe);
                await _context.SaveChangesAsync();
            }
        }

    }
}
