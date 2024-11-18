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
    public class UpdateProductService : IUpdateProductService
    {
        private readonly IRepositoryGeneric<Producto> _repository;

        public UpdateProductService(IRepositoryGeneric<Producto> repository)
        {
            _repository = repository;
        }

        public async Task<bool> UpdateProduct(long id, ProductoDto productoDto)
        {

            // Obtener el producto actual desde el repositorio
            var currentProduct = await _repository.GetById(id);

            // Verificar si el producto existe
            if (currentProduct == null)
                throw new KeyNotFoundException($"No se encontró un producto con el ID {id}.");

            // Actualizar solo las propiedades necesarias
            currentProduct.Descripcion = productoDto.Descripcion;
            currentProduct.Precio = productoDto.Precio;
            currentProduct.Nombre = productoDto.NombreProducto;

            // Ejecutar la actualización y devolver el éxito
            return await _repository.Update(currentProduct);
        }


        public async Task<bool> DeactivateProduct(long id)
        {         
            var product = await _repository.GetById(id);
            if (product == null) throw new KeyNotFoundException($"Producto con ID {id} no encontrado.");
            return await _repository.DeactivateById(product.IdProducto);
            
        }


    }
}
