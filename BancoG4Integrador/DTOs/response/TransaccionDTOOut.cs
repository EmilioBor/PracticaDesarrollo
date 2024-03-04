using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.response
{
    public class TransaccionDTOOut
    {
        

        public float Monto { get; set; }

        public long? NumeroOperacion { get; set; }

        public DateOnly? Fecha { get; set; }

        public int CuentaOrigenId { get; set; }

        public int CuentaDestinoId { get; set; }

        public int TipoTransaccionId { get; set; }
    }
}
