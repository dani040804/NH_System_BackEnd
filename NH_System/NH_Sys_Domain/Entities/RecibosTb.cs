using System;
using System.Collections.Generic;

namespace NH_Sys_Domain.Entities;

public partial class RecibosTb
{
    public long IdRecibo { get; set; }

    public long? FacturaId { get; set; }

    public decimal Monto { get; set; }

    public DateTime? FechaPago { get; set; }

    public string MetodoPago { get; set; } = null!;

    public virtual FacturasTb? Factura { get; set; }
}
