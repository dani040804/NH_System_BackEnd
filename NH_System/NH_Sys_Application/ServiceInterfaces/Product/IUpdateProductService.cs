using NH_Sys_Domain.Entities;
using NH_Sys_Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NH_Sys_Application.ServiceInterfaces.Product
{
    public interface IUpdateProductService
    {
        Task<bool> UpdateProduct(long id, ProductoDto productoDto);
        Task<bool> DeactivateProduct(long id);
    }
}
