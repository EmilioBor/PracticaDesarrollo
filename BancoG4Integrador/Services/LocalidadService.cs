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
    public class LocalidadService: ILocalidadService
    {
        private readonly BancoG4Context _contex;
        public LocalidadService(BancoG4Context contex)
        {
            _contex = contex;
        }
        public async Task<IEnumerable<LocalidadDTOOut>> GetAll()
        {
            return await _contex.Localidad.Select(l => new LocalidadDTOOut
            {
                Nombre = l.Nombre,
                Cp = l.Cp,
                IdProvincia = l.IdProvincia
            }).ToListAsync();
        }
        public async Task<Localidad?> GetID(int id)
        {
            var localidad = await _contex.Localidad
                .Where(l => l.Id == id)
                .SingleOrDefaultAsync();
            return localidad;
        }
        public async Task<Localidad> Create(LocalidadDTOIn localidad)
        {
            var nuevalocalidad = new Localidad();

            nuevalocalidad.Nombre = localidad.Nombre;
            nuevalocalidad .Cp = localidad.Cp;
            nuevalocalidad.IdProvincia = localidad.IdProvincia;

            _contex.Add(nuevalocalidad);
            await _contex.SaveChangesAsync();

            return nuevalocalidad;
        }
        public async Task Update(int id, LocalidadDTOIn localidad)
        {
            var existe = await GetID(id);
            if (existe is not null)
            {
                existe.Cp = localidad.Cp;
                existe.Nombre = localidad .Nombre;
                existe.IdProvincia = localidad .IdProvincia;
                await _contex.SaveChangesAsync();

            }
        }
        public async Task Delete(int id)
        {
            var existe = await GetID(id);
            if(existe is not null)
            {
                _contex.Localidad.Remove(existe);
                await _contex.SaveChangesAsync();
            }
        }
    }
}
