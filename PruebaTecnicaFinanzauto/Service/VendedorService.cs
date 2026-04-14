using Microsoft.EntityFrameworkCore; 
using PruebaTecnicaFinanzauto.Data;
using PruebaTecnicaFinanzauto.Models;
using PruebaTecnicaFinanzauto.Models.DTOs;

namespace PruebaTecnicaFinanzauto.Service
{
    public class VendedorService
    {
        private readonly ApplicationDbContext _context;

        public VendedorService(ApplicationDbContext context)
        {
            _context = context;
        }
        // Metodo ObtenerVendedor

        //  Obtener un vendedor por cedula
        public async Task<Vendedores> ObtenerVendedor(string cedula)
        {
            // Solo busca por cédula, no importa si está bloqueado o inactivo
            var vendedor = await _context.Vendedores.FirstOrDefaultAsync(v => v.Cedula == cedula);

            if (vendedor == null)
            {
                throw new Exception("El vendedor no existe");
            }

            return vendedor;
        }

        // Desactivar 
        public async Task DesactivarVendedor(string cedula, string motivo)
        {
            var vendedor = await ObtenerVendedor(cedula); // Buscamos al vendedor

            vendedor.Estado = EstadoVendedor.Inactivo; // Cambiamos el estado (ej. a 1 (inactivo))
            vendedor.MotivoEstado = motivo; 

            await _context.SaveChangesAsync(); 
        }

        // Bloquear 
        public async Task BloquearVendedor(string cedula, string motivo)
        {
            var vendedor = await ObtenerVendedor(cedula); // Buscamos al vendedor

            vendedor.Estado = EstadoVendedor.Bloqueado; // Cambiamos el estado (ej. a 2)
            vendedor.MotivoEstado = motivo;  

            await _context.SaveChangesAsync(); 
        }

        // Activar vendedor 
        public async Task ActivarVendedor(string cedula)
        {
            var vendedor = await ObtenerVendedor(cedula); // Buscamos al vendedor 

            if (vendedor.Estado == EstadoVendedor.Activo)
                throw new Exception("El vendedor ya se encuentra activo");

            vendedor.Estado = EstadoVendedor.Activo; // Si no esta activo se cambia el estado a Activo
            vendedor.MotivoEstado = null; // Se limpia el motivo al activar

            await _context.SaveChangesAsync();
        }


        // Crear vendedor 
        public async Task<Vendedores> CrearVendedor(Vendedores vendedor)
        {
            var existe = await _context.Vendedores.AnyAsync(v => v.Cedula == vendedor.Cedula);
            if (existe) throw new Exception("El vendedor ya existe");

            _context.Vendedores.Add(vendedor);
            await _context.SaveChangesAsync();
            return vendedor;
        }

        // llama a ObtenerVendedor en un nuevo metodopara obtener un vendedor por cedula 
        public async Task<Vendedores> ObtenerPorCedula(string cedula)
        {
            return await ObtenerVendedor(cedula);
        }
        // Se crea metodo para obtener todos los vendedores 
        public async Task<List<Vendedores>> ObtenerTodos()
        {
            return await _context.Vendedores.ToListAsync();
        }

        // Actualizar vendedor 
        public async Task ActualizarVendedor(string cedula, ActualizarVendedorDto datosActualizados)
        {

            var vendedor = await ObtenerVendedor(cedula);

            if (string.IsNullOrWhiteSpace(datosActualizados.Nombre)) throw new Exception("El nombre es obligatorio");
            if (string.IsNullOrWhiteSpace(datosActualizados.Apellido)) throw new Exception("El apellido es obligatorio");
            if (string.IsNullOrWhiteSpace(datosActualizados.Cedula)) throw new Exception("La cedula es obligatoria");

            if (vendedor.Estado != EstadoVendedor.Activo)
                throw new Exception("No se puede actualizar un vendedor que no esta activo");

            if (await _context.Vendedores.AnyAsync(ven => ven.Cedula == datosActualizados.Cedula && ven.ID != vendedor.ID))
                throw new Exception("La cedula ya esta en uso por otro vendedor");

            vendedor.Nombre = datosActualizados.Nombre;
            vendedor.Apellido = datosActualizados.Apellido;
            vendedor.Cedula = datosActualizados.Cedula;

            await _context.SaveChangesAsync();
        }
    }
}