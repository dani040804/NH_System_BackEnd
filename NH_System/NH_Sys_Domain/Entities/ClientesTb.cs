using System;
using System.Collections.Generic;

namespace NH_Sys_Domain.Entities;

public partial class ClientesTb
{
    public long IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string Identificacion { get; set; } = null!;

    public string? TipoIdentificacion { get; set; }

    public virtual ICollection<FacturasTb> FacturasTbs { get; set; } = new List<FacturasTb>();
}
