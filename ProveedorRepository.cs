using System;
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

        // Métodos para obtener, agregar, actualizar y eliminar proveedores

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
            // Aquí se realizarían las validaciones de la clase Cliente, Pedido, Producto, DetallePedido antes de agregar el proveedor
            // Por ejemplo:
            // if (!ValidarCliente(proveedor.ClienteId))
            // {
            //     throw new Exception("Cliente inválido");
            // }

            using (IDbConnection db = _conexionBD.ObtenerConexion())
            {
                string sql = "INSERT INTO Proveedor (RazonSocial, TipoDocumento, NumeroDocumento, Celular) VALUES (@RazonSocial, @TipoDocumento, @NumeroDocumento, @Celular)";
                db.Execute(sql, proveedor);
            }
        }

        public void Update(Proveedor proveedor)
        {
            // Aquí se realizarían las validaciones de la clase Cliente, Pedido, Producto, DetallePedido antes de actualizar el proveedor
            // Por ejemplo:
            // if (!ValidarPedido(proveedor.PedidoId))
            // {
            //     throw new Exception("Pedido inválido");
            // }

            using (IDbConnection db = _conexionBD.ObtenerConexion())
            {
                string sql = "UPDATE Proveedor SET RazonSocial = @RazonSocial, TipoDocumento = @TipoDocumento, NumeroDocumento = @NumeroDocumento, Celular = @Celular WHERE Id = @Id";
                db.Execute(sql, proveedor);
            }
        }

        public void Delete(int id)
        {
            // Aquí se realizarían las validaciones de la clase Cliente, Pedido, Producto, DetallePedido antes de eliminar el proveedor
            // Por ejemplo:
            // if (!ValidarProducto(proveedor.ProductoId))
            // {
            //     throw new Exception("Producto inválido");
            // }

            using (IDbConnection db = _conexionBD.ObtenerConexion())
            {
                string sql = "DELETE FROM Proveedor WHERE Id = @Id";
                db.Execute(sql, new { Id = id });
            }
        }

        // Métodos de validación de las clases Cliente, Pedido, Producto, DetallePedido
        // Debes implementar estos métodos según las reglas de validación de cada clase
        private bool ValidarCliente(int clienteId)
        {
            // Implementar lógica de validación para Cliente
            return true; // Reemplazar con la lógica real de validación
        }

        private bool ValidarPedido(int pedidoId)
        {
            // Implementar lógica de validación para Pedido
            return true; // Reemplazar con la lógica real de validación
        }

        private bool ValidarProducto(int productoId)
        {
            // Implementar lógica de validación para Producto
            return true; // Reemplazar con la lógica real de validación
        }

        private bool ValidarDetallePedido(int detallePedidoId)
        {
            // Implementar lógica de validación para DetallePedido
            return true; // Reemplazar con la lógica real de validación
        }
    }
}
