using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NH_Sys_Domain.Entities
{
    public class EscalaProducto
    {
        [Key]
        public int IdEscala { get; set; }
        public string NombreEscala { get; set; } = string.Empty;

        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    }
}
