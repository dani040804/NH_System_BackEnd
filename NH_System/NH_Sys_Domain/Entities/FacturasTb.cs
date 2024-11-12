using System;
using System.Collections.Generic;

namespace NH_Sys_Domain.Entities;

public partial class FacturasTb
{
    public long IdFactura { get; set; }

    public long? ClienteId { get; set; }

    public DateTime? FechaEmision { get; set; }

    public decimal Total { get; set; }

    public string Estado { get; set; } = null!;

    public string? ClaveHacienda { get; set; }

    public virtual ClientesTb? Cliente { get; set; }

    public virtual ICollection<DetallefacturaTb> DetallefacturaTbs { get; set; } = new List<DetallefacturaTb>();

    public virtual ICollection<RecibosTb> RecibosTbs { get; set; } = new List<RecibosTb>();
}
