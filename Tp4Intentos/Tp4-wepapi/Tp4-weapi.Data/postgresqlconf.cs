using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp4_weapi.Data
{
    public class Postgresqlconf
    {
        public Postgresqlconf(string connectionString)
        {
            ConnectionString = connectionString;
        }
         public string ConnectionString { get; set; }

    }
}
