using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.request
{
    public class ClienteXCuentaDTOIn
    {
        public int Id { get; set; }

        public DateOnly Alta { get; set; }

        public string? Rol { get; set; }

        public int ClienteId { get; set; }

        public int CuentaId { get; set; }

    }
}
