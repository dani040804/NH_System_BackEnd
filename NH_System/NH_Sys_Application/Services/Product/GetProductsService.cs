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
        private readonly IRepositoryGeneric<MarcaProducto> _marcaRepository;
        private readonly IRepositoryGeneric<EscalaProducto> _escalaRepository;
        private readonly IRepositoryGeneric<Proveedor> _proveedorRepository;
        private readonly IRepositoryGeneric<CategoriaProducto> _catRepository;


        private readonly IInventoryService _inventarioService;


        public GetProductsService( IRepositoryGeneric<Producto> repository,
            IInventoryService inventarioService, 
            IRepositoryGeneric<MarcaProducto> marcaRepository,
            IRepositoryGeneric<EscalaProducto> escalaRepository,
            IRepositoryGeneric<Proveedor> proveedorRepository,
            IRepositoryGeneric<CategoriaProducto> catRepository)
        {
            _repository = repository;
            _inventarioService = inventarioService;
            _marcaRepository = marcaRepository;
            _escalaRepository = escalaRepository;
            _proveedorRepository = proveedorRepository;
            _catRepository = catRepository;
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
                NombreProducto = product.Nombre,
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
                var stock = await _inventarioService.ConsultarStock(product.IdProducto);

                var productDto = new ProductoDto()
                {
                    IdProducto = product.IdProducto,
                    CodigoProducto = product.CodigoProducto,
                    NombreProducto = product.Nombre,
                    Marca = product.MarcaNombre,
                    Escala = product.EscalaNombre,
                    Precio = product.Precio,
                    PrecioDistribuidor = product.PrecioDistribuidor,
                    PrecioCosto = product.PrecioCosto,
                    CantidadStock = stock,
                    DescuentoAplicable = product.DescuentoAplicable


                    
                };
                productsDto.Add(productDto);
            }
            return productsDto;

        }
    
        public async Task<IEnumerable<MarcaProducto>> GetMarcas()
        {
            var marcas = await _marcaRepository.GetAll();

            if (marcas == null) throw new KeyNotFoundException("No se encontraron marcas");

            return marcas;
        }

        public async Task<IEnumerable<EscalaProducto>> GetEscalas()
        {
            var escala = await _escalaRepository.GetAll();

            if (escala == null) throw new KeyNotFoundException("No se encontraron marcas");

            return escala;
        }
        public async Task<IEnumerable<Proveedor>> GetProveedores()
        {
            var proveedor = await _proveedorRepository.GetAll();

            if (proveedor == null) throw new KeyNotFoundException("No se encontraron marcas");

            return proveedor;
        }
        public async Task<IEnumerable<CategoriaProducto>> GetCategorias()
        {
            var cat = await _catRepository.GetAll();

            if (cat == null) throw new KeyNotFoundException("No se encontraron marcas");

            return cat;
        }


    }
}
