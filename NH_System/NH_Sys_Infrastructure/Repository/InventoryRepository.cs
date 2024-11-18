using Microsoft.EntityFrameworkCore;
using NH_Sys_Domain.Entities;
using NH_Sys_Domain.Interfaces;
using NH_Sys_Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NH_Sys_Infrastructure.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        protected readonly DbDevContext _context;
        private readonly DbSet<InventarioTb> _dbSet;

        public InventoryRepository(DbDevContext context)
        {
            _context = context;
            _dbSet = _context.Set<InventarioTb>();
        }

        public async Task<InventarioTb> AddInventory(InventarioTb inventario)
        {

            try
            {
                _dbSet.Add(inventario);
                await _context.SaveChangesAsync();
                return inventario;
            }
            catch (DbUpdateException dbEx)
            {
                // Puedes registrar o mostrar el mensaje de error completo para diagnóstico
                Console.WriteLine($"Error en la base de datos: {dbEx.InnerException?.Message ?? dbEx.Message}");
                throw;  // Lanza la excepción para ser manejada en el servicio o controlador
            }
        }

        public async Task<int> ConsultInventory(long idProduct)
        {
            return await _dbSet.
                Where(i => i.ProductoId == idProduct).
                SumAsync(i => i.Cantidad);
                        
        }

        public async Task<InventarioTb> GetInventory(long idProduct, string almacen)
        {
            return await _dbSet.
                FirstOrDefaultAsync(i => i.ProductoId == idProduct && i.Ubicacion == almacen);
        }

        public async Task<bool> UpdateInventory(InventarioTb inventario)
        {
            _dbSet.Update(inventario);
            var changes = await _context.SaveChangesAsync();

            // Retorna true si hubo cambios en la base de datos
            return changes > 0;
        }
    }
}
