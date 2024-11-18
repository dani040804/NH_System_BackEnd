using System;
using System.Collections.Generic;

namespace NH_Sys_Domain.Entities;

public partial class InventarioTb
{
    public long IdInventario { get; set; }

    public long? ProductoId { get; set; }

    public int Cantidad { get; set; }

    public string? Ubicacion { get; set; }

    public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;

    public virtual Producto? Producto { get; set; }
}
