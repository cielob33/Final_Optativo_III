using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Npgsql;

namespace Final.Repository
{
    public class ConexionBD
    {
        private string connectionString;
        private NpgsqlConnection connection;

        public ConexionBD()
        {
            connectionString = "Host=localhost;Port=5432;Username=postgres;Password=12345;Database=Parcial1";
            connection = new NpgsqlConnection(connectionString);
        }

        public IDbConnection ObtenerConexion()
        {
            return connection;
        }
    }
}

