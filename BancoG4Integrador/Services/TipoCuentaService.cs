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
    public class TipoCuentaService : ITipoCuentaService
    {
        private readonly BancoG4Context _context;
        public TipoCuentaService(BancoG4Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TipoCuentaDTOOut>> GetAll()
        {
            return await _context.TipoCuenta
            .Select(t => new TipoCuentaDTOOut
            {
                
                Nombre = t.Nombre,
               Alta = t.Alta
               
            }).ToListAsync();
        }
        public async Task<TipoCuenta?> GetxId(int id)
        {
            return await _context.TipoCuenta
                .Where(p => p.Id == id)
                .Select(p => new TipoCuenta
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Alta = p.Alta
                }).SingleOrDefaultAsync();
        }
        public async Task<TipoCuenta> Create(TipoCuentaDTOIn tipoCuenta)
        {
            var nuevo = new TipoCuenta();
            nuevo.Nombre = tipoCuenta.Nombre;
            nuevo.Alta = tipoCuenta.Alta;

            _context.TipoCuenta.Add(nuevo);
            await _context.SaveChangesAsync();
            return nuevo;
        }
        public async Task Update(int id, TipoCuentaDTOIn tipoCuenta)
        {
            var existe = await GetxId(id);
            if (existe is not null)
            {
                existe.Nombre = tipoCuenta.Nombre;
                existe.Alta = tipoCuenta.Alta;

                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var existe = await GetxId(id);
            if (existe is not null)
            {
                _context.TipoCuenta.Remove(existe);
                await _context.SaveChangesAsync();
            }
        }
    }
}
