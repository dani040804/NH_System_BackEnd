using System;
using System.Collections.Generic;

namespace NH_Sys_Infrastructure;

public partial class Recibo
{
    public Guid Id { get; set; }

    public Guid? FacturaId { get; set; }

    public decimal Monto { get; set; }

    public DateTime? FechaPago { get; set; }

    public string MetodoPago { get; set; } = null!;

    public virtual Factura? Factura { get; set; }
}
