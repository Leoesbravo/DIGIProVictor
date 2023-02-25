using System;
using System.Collections.Generic;

namespace Data;

public partial class Materium
{
    public int IdMateria { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal? Costo { get; set; }

    public virtual ICollection<MateriasAsignadasAlumno> MateriasAsignadasAlumnos { get; } = new List<MateriasAsignadasAlumno>();
}
