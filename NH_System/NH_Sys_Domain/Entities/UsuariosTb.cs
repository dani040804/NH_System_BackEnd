using System;
using System.Collections.Generic;

namespace NH_Sys_Domain.Entities;

public partial class UsuariosTb
{
    public long IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string Rol { get; set; } = null!;
}
