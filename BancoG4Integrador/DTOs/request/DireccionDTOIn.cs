using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.request
{
    public class DireccionDTOIn
    {
        public int Id { get; set; }

        public string? Calle { get; set; }

        public string? Departamento { get; set; }

        public int Idlocalidad { get; set; }

        public int Numero { get; set; }
    }
}
