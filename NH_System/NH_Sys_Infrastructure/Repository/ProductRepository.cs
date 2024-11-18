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
    public class ProductRepository : IProductRepository
    {
        protected readonly DbDevContext _context;
        private readonly DbSet<Producto> _dbSet;

        public  ProductRepository(DbDevContext context)
        {
            _context = context;
            _dbSet = _context.Set<Producto>();
        }

        public async Task<Producto> Add(Producto entity)
        {
            try
            {
                _dbSet.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException dbEx)
            {
                // Puedes registrar o mostrar el mensaje de error completo para diagnóstico
                Console.WriteLine($"Error en la base de datos: {dbEx.InnerException?.Message ?? dbEx.Message}");
                throw;  // Lanza la excepción para ser manejada en el servicio o controlador
            }
        }

        public async Task<bool> DeactivateById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            return  await _dbSet.ToListAsync();
        }

        public async Task<Producto> GetById(long id)
        {
           
            return  await _dbSet.FindAsync(id);
        }

        public async Task<Producto> GetByIdInt(int id)
        {

            return await _dbSet.FindAsync(id);
        }



        public Task<IEnumerable<Producto>> GetProductsBySupplier()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Producto entity)
        {
            throw new NotImplementedException();
        }
    }
}
