using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.response
{
    public class ClienteXCuentaDTOOut
    {

        

        public DateOnly Alta { get; set; }

        public string? Rol { get; set; }

        public int ClienteId { get; set; }

        public int CuentaId { get; set; }

    }
}
