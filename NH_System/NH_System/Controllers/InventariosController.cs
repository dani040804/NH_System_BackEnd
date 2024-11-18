using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NH_Sys_Application.ServiceInterfaces.Product;
using NH_Sys_Infrastructure.DTOs;

namespace NH_Sys_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventariosController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        public InventariosController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        [Route("ConsultarStock")]
        public async Task<ActionResult<int>> ConsultarStock(long idProducto)
        {
            if (idProducto == 0 ) return BadRequest();

            try
            {
                var stock = await _inventoryService.ConsultarStock(idProducto);
                return Ok(stock);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


            
        }

        [HttpPost]
        public  ActionResult RegistrarStock(ProductoDto productoDto)
        {
            var pro = new ProductoDto();
            return StatusCode(500,"error");


        }

    }
}
