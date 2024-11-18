using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NH_Sys_Domain.Entities
{
    public class MovimientoInventario
    {
        [Key]
        public long IdMovimiento { get; set; }

        [ForeignKey("Producto")]
        public long IdProducto { get; set; }
        public string TipoMovimiento { get; set; } = string.Empty; // Entrada, Salida, Ajuste
        public int Cantidad { get; set; }
        public string Motivo { get; set; } = string.Empty; // Motivo del movimiento
        public string Almacen { get; set; } = string.Empty;
        public DateTime FechaMovimiento { get; set; } = DateTime.UtcNow;

        public virtual Producto Producto { get; set; }
    }
}
