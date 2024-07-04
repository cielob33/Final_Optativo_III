using System;
using Final.Models;
using Final.Repository;
using Final.Services;

class Program
{
    static void Main(string[] args)
    {
        // Crear una instancia de la clase ConexionBD
        ConexionBD conexionBD = new ConexionBD();

        // Instanciar los repositorios y servicios
        var proveedorRepository = new ProveedorRepository(conexionBD);
        var proveedorService = new ProveedorService(proveedorRepository);

        // Agregar un proveedor
        try
        {
            var proveedor = new Proveedor
            {
                RazonSocial = "Proveedor 1",
                TipoDocumento = "DNI",
                NumeroDocumento = "123456789",
                Celular = "0987654321"
            };

            proveedorService.AddProveedor(proveedor);

            Console.WriteLine("Proveedor agregado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Listar proveedores
        var proveedores = proveedorService.GetAllProveedores();
        foreach (var p in proveedores)
        {
            Console.WriteLine($"Id: {p.Id}, RazonSocial: {p.RazonSocial}, TipoDocumento: {p.TipoDocumento}, NumeroDocumento: {p.NumeroDocumento}, Celular: {p.Celular}");
        }

    }
}
