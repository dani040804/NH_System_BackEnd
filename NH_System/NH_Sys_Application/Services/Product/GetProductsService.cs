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

    public class GetProductsService : IGetProductsService
    {

        private readonly IRepositoryGeneric<Producto> _repository;

        public GetProductsService( IRepositoryGeneric<Producto> repository)
        {
            _repository = repository;
        }

        public async Task<ProductoDto> GetProductById(long id)
        {

            if(id == 0 && id == null) throw new ArgumentException("El ID del producto es inválido.");

            var product = await _repository.GetById(id);

            // Lanzar excepción si el producto no existe
            if (product == null)
                throw new KeyNotFoundException($"No se encontró un producto con el ID {id}.");

            // Mapear al DTO y retornar el producto
            return new ProductoDto
            {
                IdProducto = product.IdProducto,
                Nombre = product.Nombre,
                Descripcion = product.Descripcion,
                CodigoProducto = product.CodigoProducto,
                Precio = product.Precio
            };


        }

        public async  Task<IEnumerable<ProductoDto>> GetAllProducts()
        {
            var products = await _repository.GetAll();

            if (products == null) throw new KeyNotFoundException("No se encontraron productos");

            var productsDto = new List<ProductoDto>();

            foreach (var product in products) 
            {
                var productDto = new ProductoDto()
                {
                    IdProducto = product.IdProducto,
                    Nombre = product.Nombre,
                    CodigoProducto = product.CodigoProducto,
                    Precio = product.Precio,
                    Descripcion = product.Descripcion
                };
                productsDto.Add(productDto);
            }
            return productsDto;

        }
    }
}
