using System;
using System.Collections.Generic;

namespace NH_Sys_Infrastructure;

public partial class Cliente
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string Identificacion { get; set; } = null!;

    public string? TipoIdentificacion { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
