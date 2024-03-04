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
    public class CuentaService : ICuentaService
    {
        private readonly BancoG4Context _context;

        public CuentaService(BancoG4Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CuentaDTOOut>> GetAll()
        {
            return await _context.Cuenta.Select(c => new CuentaDTOOut
            {
                Cbu = c.Cbu,
                NumeroCuenta = c.NumeroCuenta,
                TipoCuentaId = c.TipoCuentaId,
                BancoId = c.BancoId
            }).ToListAsync();
        } 
        public async Task<Cuenta?> GetId(int id)
        {
            var cuenta = await _context.Cuenta
                .Where(c => c.Id == id)
                .SingleOrDefaultAsync();
            
            return cuenta;
        }
        public async Task<Cuenta> Create(CuentaDTOIn cuentaDTO)
        {
            var cuenta = new Cuenta();

            cuenta.NumeroCuenta = cuentaDTO.NumeroCuenta;
            cuenta.Cbu = cuentaDTO.Cbu;
            cuenta.TipoCuentaId = cuentaDTO.TipoCuentaId;
            cuenta.BancoId = cuentaDTO.BancoId;

            _context.Add(cuenta);
            await _context.SaveChangesAsync();
            return cuenta;
        }
        public async Task Update(int id, CuentaDTOIn cuentaDTO)
        {
            var cuenta = await GetId(id);
            if (cuenta is not null)
            {
                cuenta.NumeroCuenta = cuentaDTO.NumeroCuenta;
                cuenta.Cbu = cuentaDTO.Cbu;
                cuenta.TipoCuentaId = cuentaDTO.TipoCuentaId;
                cuenta.BancoId=cuentaDTO.BancoId;

                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var existe = await GetId(id);
            if (existe is not null)
            {
                _context.Cuenta.Remove(existe);
                await _context.SaveChangesAsync();
            }
        }
    }
}
