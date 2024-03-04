using Data.Models;
using DTOs.request;
using DTOs.response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TransaccionesService: ITransaccionesService
    {
        private readonly BancoG4Context _context;
        public TransaccionesService(BancoG4Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TransaccionDTOOut>> GetAll()
        {
            return await _context.Transaccion
            .Select(t => new TransaccionDTOOut
            {
                Monto = t.Monto,
                Fecha = t.Fecha,
                CuentaDestinoId = t.CuentaDestinoId,
                CuentaOrigenId = t.CuentaOrigenId,
                NumeroOperacion = t.NumeroOperacion,
                TipoTransaccionId = t.TipoTransaccionId
            }).ToListAsync();
        }
        public async Task<Transaccion?> GetxId(int id)
        {
            return await _context.Transaccion
                .Where(t => t.Id == id)
                .Select(t => new Transaccion
                {
                    Id = t.Id,
                    Monto = t.Monto,
                    Fecha = t.Fecha,
                    CuentaDestinoId = t.CuentaDestinoId,
                    CuentaOrigenId = t.CuentaOrigenId,
                    NumeroOperacion = t.NumeroOperacion,
                    TipoTransaccionId = t.TipoTransaccionId

                }).SingleOrDefaultAsync();
        }
        public async Task<Transaccion> Create(TransaccionDTOIn transaccion)
        {
            var nuevo = new Transaccion();

            nuevo.Monto = transaccion.Monto;
            nuevo.Fecha = transaccion.Fecha;
            nuevo.CuentaDestinoId = transaccion.CuentaDestinoId;
            nuevo.CuentaOrigenId = transaccion.CuentaOrigenId;
            nuevo.NumeroOperacion = transaccion.NumeroOperacion;
            nuevo.TipoTransaccionId = transaccion.TipoTransaccionId;

            _context.Transaccion.Add(nuevo);
            await _context.SaveChangesAsync();
            return nuevo;
        }
        public async Task Update(int id, TransaccionDTOIn transaccion)
        {
            var existe = await GetxId(id);
            if (existe is not null)
            {
                existe.Monto = transaccion.Monto;
                existe.Fecha = transaccion.Fecha;
                existe.CuentaDestinoId = transaccion.CuentaDestinoId;
                existe.CuentaOrigenId = transaccion.CuentaOrigenId;
                existe.NumeroOperacion = transaccion.NumeroOperacion;
                existe.TipoTransaccionId = transaccion.TipoTransaccionId;

                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var existe = await GetxId(id);
            if (existe is not null)
            {
                _context.Transaccion.Remove(existe);
                await _context.SaveChangesAsync();
            }
        }
    }
}
