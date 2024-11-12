using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NH_Sys_Domain.Interfaces
{
    public interface IRepositoryGeneric<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(long id);
        Task<T> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> DeactivateById(long id);
    }
}
