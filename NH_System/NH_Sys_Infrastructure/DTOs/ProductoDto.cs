using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NH_Sys_Infrastructure.DTOs
{
    public class ProductoDto
    {
        public long IdProducto { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public string CodigoProducto { get; set; } = null!;
    }
}
