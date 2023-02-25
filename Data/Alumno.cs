using System;
using System.Collections.Generic;

namespace Data;

public partial class Alumno
{
    public int IdAlumno { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apaterno { get; set; } = null!;

    public string? Amaterno { get; set; }

    public string? Imagen { get; set; }

    public virtual ICollection<MateriasAsignadasAlumno> MateriasAsignadasAlumnos { get; } = new List<MateriasAsignadasAlumno>();
}
