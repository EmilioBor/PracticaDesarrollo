using Data.Models;
using DTOs.request;
using DTOs.response;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TipoTransaccionService : ITipoTransaccionService
    {
        private readonly BancoG4Context _context;
        public TipoTransaccionService(BancoG4Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TipoTransaccionDTOOut>> GetAll()
        {
            return await _context.TipoTransaccion
            .Select(t => new TipoTransaccionDTOOut
            {

                Nombre = t.Nombre


            }).ToListAsync();
        }
        public async Task<TipoTransaccion?> GetxId(int id)
        {
            return await _context.TipoTransaccion
                .Where(p => p.Id == id)
                .Select(p => new TipoTransaccion
                {
                    Id = p.Id,
                    Nombre = p.Nombre,

                }).SingleOrDefaultAsync();
        }
        public async Task<TipoTransaccion> Create(TipoTransaccionDTOIn tipoTransaccion)
        {
            var nuevo = new TipoTransaccion();
            nuevo.Nombre = tipoTransaccion.Nombre;


            _context.TipoTransaccion.Add(nuevo);
            await _context.SaveChangesAsync();
            return nuevo;
        }
        public async Task Update(int id, TipoTransaccionDTOIn tipoTransaccion)
        {
            var existe = await GetxId(id);
            if (existe is not null)
            {
                existe.Nombre = tipoTransaccion.Nombre;


                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var existe = await GetxId(id);
            if (existe is not null)
            {
                _context.TipoTransaccion.Remove(existe);
                await _context.SaveChangesAsync();
            }
        }
    }
}
