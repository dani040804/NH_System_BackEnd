using System;
using System.Collections.Generic;

namespace NH_Sys_Infrastructure;

public partial class Usuario
{
    public Guid Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string Rol { get; set; } = null!;
}
