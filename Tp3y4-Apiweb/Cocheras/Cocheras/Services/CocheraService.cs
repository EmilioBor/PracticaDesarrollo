using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Request;
using Core.Response;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interface;

namespace Services
{
    public class CocheraService : ICocheraService
    {
        private readonly AutosBDContext _contex;

        public CocheraService(AutosBDContext contex) { _contex = contex; }

        public async Task<IEnumerable<CocheraDtoOut>> GetAll()
        {
            return await _contex.Cocheras
                .Select(a => new CocheraDtoOut
                {
                    Id = a.Id,
                    RazonSocial = a.Nombre
                    

                }).ToListAsync();
        }
        //public async Task<CocheraDtoOut?> GetById(int id)
        //{
        //    return await _contex.Cochera.Where(a => a.Id == id).Select(a => new CocheraDtoOut
        //    {
        //        Id = a.Id,
                

        //    }).SingleOrDefaultAsync();
        //}
        public async Task<Cocheras?> GetId(int id)
        {
            return await _contex.Cocheras
                .Where(a => a.Id == id)
                .Select(a => new Cocheras
                {
                    Id = a.Id,
                    Nombre = a.Nombre
                }).SingleOrDefaultAsync();
        }
        public async Task<Cocheras> Create(CocheraDtoIn cochera)
        {
            var nuevoAuto = new Cocheras();

            nuevoAuto.Id = cochera.Id;
            nuevoAuto.Nombre = cochera.RazonSocial;

            _contex.Cocheras.Add(nuevoAuto);
            await _contex.SaveChangesAsync();
            return nuevoAuto;
        }
        public async Task Update(int id, CocheraDtoIn cochera)
        {
            var existe = await GetId(id);
            if (existe != null)
            {

                var nuevoAuto = new Cocheras();

                nuevoAuto.Id = cochera.Id;
                nuevoAuto.Nombre = cochera.RazonSocial;
                //_contex.Cocheras.Attach(nuevoAuto);
                await _contex.SaveChangesAsync();
            }

        }
        public async Task Delete(int id)
        {
            var existe = await GetId(id);
            if (existe is not null)
            {
                
                _contex.Cocheras.Remove(existe);
                await _contex.SaveChangesAsync();
            }
        }
    }
}
