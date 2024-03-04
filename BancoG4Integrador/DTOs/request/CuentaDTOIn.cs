using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.request
{
    public class CuentaDTOIn
    {
        public int Id { get; set; }

        public int NumeroCuenta { get; set; }

        public int Cbu { get; set; }

        public int TipoCuentaId { get; set; }

        public int BancoId { get; set; }
    }
}
