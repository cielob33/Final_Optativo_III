using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Data;
using Dapper;
using Final.Models;

namespace Final.Repository
{
    public class ProveedorRepository
    {
        private readonly ConexionBD _conexionBD;

        public ProveedorRepository(ConexionBD conexionBD)
        {
            _conexionBD = conexionBD;
        }

        public IEnumerable<Proveedor> GetAll()
        {
            using (IDbConnection db = _conexionBD.ObtenerConexion())
            {
                return db.Query<Proveedor>("SELECT * FROM Proveedor");
            }
        }

        public Proveedor GetById(int id)
        {
            using (IDbConnection db = _conexionBD.ObtenerConexion())
            {
                return db.QuerySingleOrDefault<Proveedor>("SELECT * FROM Proveedor WHERE Id = @Id", new { Id = id });
            }
        }

        public void Add(Proveedor proveedor)
        {
            using (IDbConnection db = _conexionBD.ObtenerConexion())
            {
                string sql = "INSERT INTO Proveedor (RazonSocial, TipoDocumento, NumeroDocumento, Celular) VALUES (@RazonSocial, @TipoDocumento, @NumeroDocumento, @Celular)";
                db.Execute(sql, proveedor);
            }
        }

        public void Update(Proveedor proveedor)
        {
            using (IDbConnection db = _conexionBD.ObtenerConexion())
            {
                string sql = "UPDATE Proveedor SET RazonSocial = @RazonSocial, TipoDocumento = @TipoDocumento, NumeroDocumento = @NumeroDocumento, Celular = @Celular WHERE Id = @Id";
                db.Execute(sql, proveedor);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = _conexionBD.ObtenerConexion())
            {
                string sql = "DELETE FROM Proveedor WHERE Id = @Id";
                db.Execute(sql, new { Id = id });
            }
        }
    }
}
