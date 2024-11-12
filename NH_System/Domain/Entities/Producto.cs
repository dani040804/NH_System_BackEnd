using System;
using System.Collections.Generic;

namespace NH_Sys_Infrastructure;

public partial class Producto
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public string CodigoProducto { get; set; } = null!;

    public virtual ICollection<Detallefactura> Detallefacturas { get; set; } = new List<Detallefactura>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}
