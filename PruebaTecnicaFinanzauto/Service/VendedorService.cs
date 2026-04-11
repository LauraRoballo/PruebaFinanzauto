using PruebaTecnicaFinanzauto.Data;
using PruebaTecnicaFinanzauto.Models;

namespace PruebaTecnicaFinanzauto.Service
{
    public class VendedorService
    {
        private readonly ApplicationDbContext _context;

        public VendedorService(ApplicationDbContext context)
        {
            _context = context;
        }


        // Obtener un vendedor por su cedula, si no existe lanza una excepcion
        private Vendedores ObtenerVendedor(string cedula)
        {
            var vendedor = _context.Vendedores
                .FirstOrDefault(v => v.Cedula == cedula);

            if (vendedor == null)
            {
                throw new Exception("El vendedor no existe");
            }

            return vendedor;
        }

        // Validar si el vendedor NO existe, si ya existe lanza una excepcion (crear)
        public void ValidarVendedorNoExiste(string cedula)
        {
            var vendedor = _context.Vendedores
                .FirstOrDefault(ven => ven.Cedula == cedula);

            if (vendedor != null)
            {
                throw new Exception("El vendedor ya existe");
            }
        }

        // Validar que el vendedor este activo
        public void ValidarVendedorActivo(string cedula)
        {
            var vendedor = ObtenerVendedor(cedula);

            if (vendedor.Estado != EstadoVendedor.Activo)
            {
                throw new Exception("El vendedor no esta activo");
            }
        }

        // Desactivar un vendedor 
        public void DesactivarVendedor(string cedula, string motivo)
        {
            var vendedor = ObtenerVendedor(cedula);

            vendedor.Estado = EstadoVendedor.Inactivo;
            vendedor.MotivoEstado = motivo;

            _context.SaveChanges();
        }

        // Bloquear un vendedor
        public void BloquearVendedor(string cedula, string motivo)
        {
            var vendedor = ObtenerVendedor(cedula);

            vendedor.Estado = EstadoVendedor.Bloqueado;
            vendedor.MotivoEstado = motivo;

            _context.SaveChanges();
        }
        // Metodo para activar un vendedor de nuevo 
        public void ActivarVendedor(string cedula)
        {
            var vendedor = ObtenerVendedor(cedula);

            if (vendedor.Estado == EstadoVendedor.Activo)
            {
                throw new Exception("El vendedor ya se encuentra activo");
            }

            vendedor.Estado = EstadoVendedor.Activo; 
            vendedor.MotivoEstado = null; // Limpia el motivo al activar nuevamente

            _context.SaveChanges();
        }

        // Crear vendedor 
        public Vendedores CrearVendedor(Vendedores vendedor)
        {
            ValidarVendedorNoExiste(vendedor.Cedula);

            // agrega el vendedor 
            _context.Vendedores.Add(vendedor);

            // guarda el vendedor 
            _context.SaveChanges();

            return vendedor;
        }

       
    }
}