using NH_Sys_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NH_Sys_Domain.Interfaces
{
    public interface IProductRepository : IRepositoryGeneric<Producto>
    {
        Task<IEnumerable<Producto>> GetProductsBySupplier();
    }
}
