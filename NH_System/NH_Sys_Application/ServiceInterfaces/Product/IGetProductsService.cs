using NH_Sys_Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NH_Sys_Application.ServiceInterfaces.Product
{
    public interface IGetProductsService
    {
        Task<IEnumerable<ProductoDto>> GetAllProducts();
        Task <ProductoDto> GetProductById(long id);
    }
}
