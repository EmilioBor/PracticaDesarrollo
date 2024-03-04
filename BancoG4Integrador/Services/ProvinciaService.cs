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
    public class ProvinciaService : IProvinciaService
    {
        private readonly BancoG4Context _context;
        public ProvinciaService(BancoG4Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Provincia>> GetAll()
        {
            return await _context.Provincia
            .Select(p => new Provincia
            {
                Id = p.Id,
                Nombre = p.Nombre
            }).ToListAsync();
        }
        public async Task<Provincia?> GetxId(int id)
        {
            return await _context.Provincia
                .Where(p => p.Id == id)
                .Select(p => new Provincia
                {
                    Id = p.Id,
                    Nombre = p.Nombre
                }).SingleOrDefaultAsync();
        }
        public async Task<Provincia> Create(ProvinciumDTOIn paisDTOIn)
        {
            var nuevoProvincia = new Provincia();
            nuevoProvincia.Nombre = paisDTOIn.Nombre;

            _context.Provincia.Add(nuevoProvincia);
            await _context.SaveChangesAsync();
            return nuevoProvincia;
        }
        public async Task Update(int id, ProvinciumDTOIn pais)
        {
            var existePais = await GetxId(id);
            if (existePais is not null)
            {
                existePais.Nombre = pais.Nombre;
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var existe = await GetxId(id);
            if (existe is not null)
            {
                _context.Provincia.Remove(existe);
                await _context.SaveChangesAsync();
            }
        }
    }
}

