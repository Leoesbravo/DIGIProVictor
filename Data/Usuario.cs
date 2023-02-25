using System;
using System.Collections.Generic;

namespace Data;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Correo { get; set; } = null!;

    public string? Password { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }
}
