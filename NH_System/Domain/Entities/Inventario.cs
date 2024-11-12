using System;
using System.Collections.Generic;

namespace NH_Sys_Infrastructure;

public partial class Inventario
{
    public Guid Id { get; set; }

    public Guid? ProductoId { get; set; }

    public int Cantidad { get; set; }

    public string? Ubicacion { get; set; }

    public virtual Producto? Producto { get; set; }
}
