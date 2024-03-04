using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Request
{
    public class AutosDtoIn
    {
        public int Id { get; set; }

        public string? Marca { get; set; }

        public string? Modelo { get; set; }

        public string? Color { get; set; }

        public int Puerta { get; set; }

        public int IdCochera { get; set; }
    }
}
