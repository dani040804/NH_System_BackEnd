using Microsoft.EntityFrameworkCore;
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
        private readonly IRepositoryGeneric<MarcaProducto> _repositoryMarca;
        private readonly IRepositoryGeneric<EscalaProducto> _repositoryEscala;

        private readonly IInventoryService _inventoryService;


        public AddProductService(IRepositoryGeneric<Producto> repositoryGeneric, IRepositoryGeneric<EscalaProducto> repositoryEscala, IRepositoryGeneric<MarcaProducto> repositoryMarca, IInventoryService inventoryService)
        {
            _repositoryGeneric = repositoryGeneric;
            _inventoryService = inventoryService;
            _repositoryEscala = repositoryEscala;
            _repositoryMarca = repositoryMarca;
        }

        public async  Task<bool> CreateProducto(ProductoDto productoDto)
        {

            var escala = await _repositoryEscala.GetByIdInt(productoDto.IdEscala);
            var marca = await _repositoryMarca.GetByIdInt(productoDto.IdMarca);

            var producto = new Producto()
            {
                Nombre = productoDto.NombreProducto,
                Descripcion = productoDto.Descripcion,
                Precio = productoDto.Precio,
                PrecioDistribuidor = productoDto.PrecioDistribuidor,
                PrecioCosto = productoDto.PrecioCosto,
                CodigoProducto = "NH00000",
                IdProveedor = productoDto.IdProveedor,
                DescuentoAplicable = productoDto.DescuentoAplicable,
                MarcaId = productoDto.IdMarca,
                MarcaNombre = marca.NombreMarca,
                EscalaId = productoDto.IdEscala,
                EscalaNombre = escala.NombreEscala,
                IdCategoriaProducto = productoDto.IdCategoriaProducto,
                

            };
            try
            {
                var result = await _repositoryGeneric.Add(producto);
                if (result != null && result.IdProducto != 0)
                {
                    await _inventoryService.RegistrarEntrada(result.IdProducto, productoDto.CantidadStock, "Ingreso de inventario inicial");


                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (DbUpdateException dbEx)
            {
                // Maneja errores específicos de la base de datos

                throw new InvalidOperationException("Ocurrió un error al guardar el producto en la base de datos. Intente de nuevo más tarde.", dbEx);
            }
            catch (Exception ex)
            {
                // Maneja otros errores generales

                throw new Exception("Se produjo un error inesperado al crear el producto. Verifique los detalles del error.", ex);
            }
        }

            

           


        
    }
}
