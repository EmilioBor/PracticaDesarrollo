using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.request
{
    public class ProvinciumDTOIn
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public int? IdPais { get; set; }
    }
}
