using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp4_webapi.Model;

namespace Tp4_weapi.Data.Repositories
{
    public class AutoRepository : IAutoRepository
    {
        private Postgresqlconf _postgresqlconf;
        public AutoRepository(Postgresqlconf postgresqlconf)
        {
            _postgresqlconf = postgresqlconf;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_postgresqlconf.ConnectionString);
        }

        public async Task<bool> ActAuto(Auto auto)
        {
            var db = dbConnection();

            var sql = @"
                UPDATE public. ""Autos""
                SET marca = @Marca,
                    modelo = @Modelo,
                    color = @Color,
                    año = @Año,
                    puerta = @Puerta
                WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { auto.Id, auto.Marca, auto.Modelo, auto.Color, auto.Año, auto.Puerta });

            return result > 0;
        }

        public async Task<bool> EliAuto(Auto auto, int id)
        {
            var db = dbConnection();

            var sql = @"
                DELETE
                FROM public. ""Autos""
                WHERE id = @Id
            ";
             var result= await db.ExecuteAsync(sql, new { Id = auto.Id });
            return result > 0;
        }

        public async Task<IEnumerable<Auto>> GetAllAutos()
        {
            var db = dbConnection();

            var sql = @"
                SELECT id, Marca, Modelo, Color, año, puerta
                FROM public. ""Autos""
                
            ";
            return await db.QueryAsync<Auto>( sql, new {});
        }

        public async Task<Auto?> GetAutoDetalle(int id)
        {
            var db = dbConnection();

            var sql = @"
                SELECT id, Marca, Modelo, Color, año, puerta
                FROM public. ""Autos""
                WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Auto>(sql, new { Id = id });
        }

        public async Task<bool> InsertarAuto(Auto auto)
        {
            var db = dbConnection();

            var sql = @"
                INSERT INTO public. ""Autos"" (marca, modelo, color, año, puerta)
                VALUES(@Marca, @Modelo, @Color, @Año, @Puerta)
                ";

            var result = await db.ExecuteAsync(sql, new {auto.Marca, auto.Modelo, auto.Color, auto.Año, auto.Puerta});

            return result > 0;
        }
    }
}
