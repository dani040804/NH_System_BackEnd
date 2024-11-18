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

        public string NombreProducto { get; set; } = null!;

        public string Descripcion { get; set; } = string.Empty;

        public bool DescuentoAplicable { get; set; }

        public string Marca { get; set; } = string.Empty;
        public int IdMarca { get; set; }


        public string Escala { get; set; } = string.Empty;
        public int IdEscala { get; set; }


        public string Categoria { get; set; } = string.Empty;

        public string? SubCategoria { get; set; } = string.Empty;

        public long IdProveedor { get; set; }

        public string Proveedor { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public decimal PrecioDistribuidor { get; set; }

        public decimal PrecioCosto { get; set; }

        public string CodigoProducto { get; set; } = null!;

        public int CantidadStock { get; set; }

        public long IdCategoriaProducto { get; set; }
    }
}
