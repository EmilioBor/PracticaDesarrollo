using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp4_webapi.Model;

namespace Tp4_weapi.Data.Repositories
{

    public interface IAutoRepository
    {
        Task<IEnumerable<Auto>> GetAllAutos();//Metodo que devuelve todos los autos

        Task<Auto>  GetAutoDetalle(int id);//Solo uno

        Task<bool> InsertarAuto(Auto auto);//insertamos

        Task<bool> ActAuto(Auto auto);//actualizar

        Task<bool> EliAuto(Auto auto, int id);//Eliminar
        
    }
}
