using System;
using System.Collections.Generic;

namespace NH_Sys_Domain.Entities;

public partial class Producto
{
    public long IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public string CodigoProducto { get; set; } = null!;

    public bool IsActive { get; set; } = true;

    public virtual ICollection<DetallefacturaTb> DetallefacturaTbs { get; set; } = new List<DetallefacturaTb>();

    public virtual ICollection<InventarioTb> InventarioTbs { get; set; } = new List<InventarioTb>();
}
