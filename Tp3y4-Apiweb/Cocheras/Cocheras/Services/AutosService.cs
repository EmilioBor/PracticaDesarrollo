using Core.Request;
using Core.Response;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interface;

namespace Services
{
    public class AutosService : IAutosService
    {
        private readonly AutosBDContext _contex;

        public AutosService(AutosBDContext contex) { _contex = contex; }

        public async Task<IEnumerable<AutosDtoOut>> GetAll()
        {
            return await _contex.Autos
                .Select(a => new AutosDtoOut
                {
                    Id = a.Id,
                    Modelo = a.Modelo,
                    Marca = a.Marca,
                    Puerta = a.Puerta,
                    Color = a.Color,
                 
                    NombreCochera = a.IdCocheraNavigation.Nombre

                }).ToListAsync();
        }
        public async Task<Autos?> GetById(int id)
        {
            return await _contex.Autos.FirstAsync();
            
                
        }
        public async Task<AutosDtoOut?> GetId(int id)
        {
            return await _contex.Autos
                .Where(a => a.Id == id)
                .Select(a => new AutosDtoOut
            {
                Id = a.Id,
                Modelo = a.Modelo,
                Marca = a.Marca,
                Puerta = a.Puerta,
                Color = a.Color,

                    NombreCochera = a.IdCocheraNavigation.Nombre
                }).SingleOrDefaultAsync();
        }
        public async Task<Autos> Create(AutosDtoIn autos)
        {
            var nuevoAuto = new Autos();

            nuevoAuto.Id = autos.Id;
            nuevoAuto.Modelo = autos.Modelo;
            nuevoAuto.Marca = autos.Marca;
            nuevoAuto.Puerta = autos.Puerta;
            nuevoAuto.Color = autos.Color;
            //nuevoAuto.Año = DateTime.Now;
            nuevoAuto.IdCochera = autos.IdCochera;

            _contex.Autos.Add(nuevoAuto);
            await _contex.SaveChangesAsync();
            return nuevoAuto;
        }
        public async Task Update(int id, AutosDtoIn autos)
        {
            var existe = await GetId(id);
            if (existe != null)
            {

                var nuevoAuto = new Autos();

                nuevoAuto.Id = autos.Id;
                nuevoAuto.Modelo = autos.Modelo;
                nuevoAuto.Marca = autos.Marca;
                nuevoAuto.Puerta = autos.Puerta;
                nuevoAuto.Color = autos.Color;
                //nuevoAuto.Año = autos.Año;
                nuevoAuto.IdCochera = autos.IdCochera;
                
                await _contex.SaveChangesAsync();
            }
                
        }
        public async Task Delete(int id)
        {
            var existe = await GetById(id);
            if(existe is not null)
            {
                _contex.Autos.Remove(existe);
                await _contex.SaveChangesAsync();
            }
        }
    }
}
