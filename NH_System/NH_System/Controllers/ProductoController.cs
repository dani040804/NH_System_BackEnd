﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NH_Sys_Application.ServiceInterfaces.Product;
using NH_Sys_Domain.Entities;
using NH_Sys_Domain.Interfaces;
using NH_Sys_Infrastructure.Data;
using NH_Sys_Infrastructure.DTOs;

namespace NH_Sys_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly DbDevContext _context;
        private readonly IAddProductService _addProductService;
        private readonly IGetProductsService _getProductsService;
        private readonly IProductRepository _productRepository;
        private readonly IUpdateProductService _updateProductService;

        public ProductoController(DbDevContext context, IAddProductService addProductService, IGetProductsService getProductsService, IProductRepository productRepository, IUpdateProductService updateProductService)
        {
            _context = context;
            _addProductService = addProductService;
            _getProductsService = getProductsService;
            _updateProductService = updateProductService;
        }


        [HttpGet]
        [Route("Marcas")]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetMarcas()
        {
            try
            {
                var marcas = await _getProductsService.GetMarcas();
                return Ok(marcas);
            }
            catch (KeyNotFoundException ex)
            {

                return NotFound(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales
                return StatusCode(500, new { mensaje = "Ocurrió un error en el servidor.", detalle = ex.Message });
            }
        }

        [HttpGet]
        [Route("Escalas")]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetEscalas()
        {
            try
            {
                var escalas = await _getProductsService.GetEscalas();
                return Ok(escalas);
            }
            catch (KeyNotFoundException ex)
            {

                return NotFound(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales
                return StatusCode(500, new { mensaje = "Ocurrió un error en el servidor.", detalle = ex.Message });
            }
        }

        [HttpGet]
        [Route("Categorias")]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetCategorias()
        {
            try
            {
                var categorias = await _getProductsService.GetCategorias();
                return Ok(categorias);
            }
            catch (KeyNotFoundException ex)
            {

                return NotFound(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales
                return StatusCode(500, new { mensaje = "Ocurrió un error en el servidor.", detalle = ex.Message });
            }
        }

        [HttpGet]
        [Route("Proveedores")]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetProveedores()
        {
            try
            {
                var proveedores = await _getProductsService.GetProveedores();
                return Ok(proveedores);
            }
            catch (KeyNotFoundException ex)
            {

                return NotFound(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales
                return StatusCode(500, new { mensaje = "Ocurrió un error en el servidor.", detalle = ex.Message });
            }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetProductos()
        {
            try
            {
                var products = await _getProductsService.GetAllProducts();
                return Ok(products);
            }
            catch (KeyNotFoundException ex)
            {

                return NotFound(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales
                return StatusCode(500, new { mensaje = "Ocurrió un error en el servidor.", detalle = ex.Message });
            }
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(long id)
        {
            try
            {
                var product = await _getProductsService.GetProductById(id);
                return Ok(product);
            }
            catch (KeyNotFoundException ex)
            {
                // Retornar un 404 si el producto no se encuentra
                return NotFound(new { mensaje = ex.Message });
            }
            catch (ArgumentException ex)
            {
                // Retornar un 400 si el ID es inválido
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales
                return StatusCode(500, new { mensaje = "Ocurrió un error en el servidor.", detalle = ex.Message });
            }

        }

        // PUT: api/Productos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(long id, ProductoDto productDto)
        {
            if (productDto == null || id != productDto.IdProducto)
            {
                return BadRequest("Los datos del cliente son inválidos.");
            }

            try
            {

                await _updateProductService.UpdateProduct(id, productDto);

                return Ok(new { codigo = 0, mensaje = "Cliente actualizado correctamente." });
            }
            catch (KeyNotFoundException ex)
            {
                // Retornar un 404 si el producto no se encuentra
                return NotFound(new { mensaje = ex.Message });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Productos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostProducto(ProductoDto producto)
        {
            if (producto == null) { return BadRequest(); }

            try
            {
                bool result = await _addProductService.CreateProducto(producto);

                if (result) return Created();
                else return BadRequest("No se puedo crear el producto");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(long id)
        {
            var Producto = await _context.Productos.FindAsync(id);
            if (Producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(Producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //PATCH: api/Clientes/DesactivarCliente/5
        [HttpPatch("DesactivarProducto/{id}")]
        public async Task<IActionResult> DesactivarCliente(long id)
        {
            var response = await _updateProductService.DeactivateProduct(id);
            return Ok(response);
        }


        private bool ProductoExists(long id)
        {
            return _context.Productos.Any(e => e.IdProducto == id);
        }


    }
}
