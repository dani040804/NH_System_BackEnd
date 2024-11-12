using System;
using System.Collections.Generic;

namespace NH_Sys_Domain.Entities;

public partial class DetallefacturaTb
{
    public long IdDetalleFactura { get; set; }

    public long? FacturaId { get; set; }

    public long? ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Subtotal { get; set; }

    public virtual FacturasTb? Factura { get; set; }

    public virtual Producto? Producto { get; set; }
}
