using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using Final.Models;
using Final.Repository;

namespace Final.Services
{
    public class ProveedorService
    {
        private readonly ProveedorRepository _repository;

        public ProveedorService(ProveedorRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Proveedor> GetAllProveedores()
        {
            return _repository.GetAll();
        }

        public Proveedor GetProveedorById(int id)
        {
            return _repository.GetById(id);
        }

        public void AddProveedor(Proveedor proveedor)
        {
            // Validaciones
            if (string.IsNullOrEmpty(proveedor.RazonSocial) || proveedor.RazonSocial.Length < 3)
                throw new ArgumentException("Razón Social es obligatoria y debe tener al menos 3 caracteres.");
            if (string.IsNullOrEmpty(proveedor.TipoDocumento))
                throw new ArgumentException("Tipo de Documento es obligatorio.");
            if (string.IsNullOrEmpty(proveedor.NumeroDocumento) || proveedor.NumeroDocumento.Length < 3)
                throw new ArgumentException("Número de Documento es obligatorio y debe tener al menos 3 caracteres.");
            if (string.IsNullOrEmpty(proveedor.Celular) || proveedor.Celular.Length != 10)
                throw new ArgumentException("Celular debe ser numérico y de longitud 10.");

            _repository.Add(proveedor);
        }

        public void UpdateProveedor(Proveedor proveedor)
        {
            // Validaciones
            if (string.IsNullOrEmpty(proveedor.RazonSocial) || proveedor.RazonSocial.Length < 3)
                throw new ArgumentException("Razón Social es obligatoria y debe tener al menos 3 caracteres.");
            if (string.IsNullOrEmpty(proveedor.TipoDocumento))
                throw new ArgumentException("Tipo de Documento es obligatorio.");
            if (string.IsNullOrEmpty(proveedor.NumeroDocumento) || proveedor.NumeroDocumento.Length < 3)
                throw new ArgumentException("Número de Documento es obligatorio y debe tener al menos 3 caracteres.");
            if (string.IsNullOrEmpty(proveedor.Celular) || proveedor.Celular.Length != 10)
                throw new ArgumentException("Celular debe ser numérico y de longitud 10.");

            _repository.Update(proveedor);
        }

        public void DeleteProveedor(int id)
        {
            _repository.Delete(id);
        }
    }
}
