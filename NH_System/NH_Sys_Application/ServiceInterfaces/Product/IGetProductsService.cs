using NH_Sys_Domain.Entities;
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
        Task<IEnumerable<MarcaProducto>> GetMarcas();
        Task<IEnumerable<EscalaProducto>> GetEscalas();
        Task<IEnumerable<Proveedor>> GetProveedores();
        Task<IEnumerable<CategoriaProducto>> GetCategorias();


        Task<ProductoDto> GetProductById(long id);
    }
}
