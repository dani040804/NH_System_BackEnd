using NH_Sys_Application.ServiceInterfaces.Product;
using NH_Sys_Domain.Entities;
using NH_Sys_Domain.Interfaces;
using NH_Sys_Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NH_Sys_Application.Services.Product
{
    public class AddProductService : IAddProductService
    {
        private readonly IRepositoryGeneric<Producto> _repositoryGeneric;

        public AddProductService(IRepositoryGeneric<Producto> repositoryGeneric)
        {
            _repositoryGeneric = repositoryGeneric;
        }

        public async  Task<Producto> CreateProducto(ProductoDto productoDto)
        {
            var producto = new Producto()
            {
                Nombre = productoDto.Nombre,
                Descripcion = productoDto.Descripcion,
                Precio = productoDto.Precio,
                CodigoProducto = "MN12039"
            };

            var result = await _repositoryGeneric.Add(producto);

            if (result != null && result.IdProducto != 0) 
            { 
                return result;
            }
            else
            {
                return result;
            }


        }
    }
}
