using Microsoft.EntityFrameworkCore;
using NH_Sys_Domain.Interfaces;
using NH_Sys_Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle_Designer_Data.Repository
{
    public class Repository<T> : IRepositoryGeneric<T> where T : class
    {
        protected readonly DbDevContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbDevContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> Add(T entity)
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
            var entity = await _dbSet.FindAsync(id);

            if(entity == null) return false;//No se encontró la entidad

            var isActive = entity.GetType().GetProperty("IsActive");

            if (isActive != null)
            {
                isActive.SetValue(entity, false);
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;//Tiene campo IsActive nulo

        }

        public async  Task<IEnumerable<T>> GetAll()
        {
            var entities = await _dbSet.ToListAsync();
            if (entities == null) return Enumerable.Empty<T>();
            else
                return entities;
        }

        public async Task<T> GetById(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetByIdInt(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> Update(T entity)
        {
            _dbSet.Update(entity);
            var changes = await _context.SaveChangesAsync();

            // Retorna true si hubo cambios en la base de datos
            return changes > 0;
        }
    }
}
