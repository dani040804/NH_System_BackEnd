using System;
using System.Collections.Generic;

namespace NH_Sys_Infrastructure;

public partial class Factura
{
    public Guid Id { get; set; }

    public Guid? ClienteId { get; set; }

    public DateTime? FechaEmision { get; set; }

    public decimal Total { get; set; }

    public string Estado { get; set; } = null!;

    public string? ClaveHacienda { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<Detallefactura> Detallefacturas { get; set; } = new List<Detallefactura>();

    public virtual ICollection<Recibo> Recibos { get; set; } = new List<Recibo>();
}
