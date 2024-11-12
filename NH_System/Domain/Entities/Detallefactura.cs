using System;
using System.Collections.Generic;

namespace NH_Sys_Infrastructure;

public partial class Detallefactura
{
    public Guid Id { get; set; }

    public Guid? FacturaId { get; set; }

    public Guid? ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Subtotal { get; set; }

    public virtual Factura? Factura { get; set; }

    public virtual Producto? Producto { get; set; }
}
