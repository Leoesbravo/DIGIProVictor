﻿using System;
using System.Collections.Generic;

namespace Data;

public partial class MateriasAsignadasAlumno
{
    public int IdAlumnoMateria { get; set; }

    public int? IdAlumno { get; set; }

    public int? IdMateria { get; set; }
    public string? NombreMateria { get; set; }
    public decimal Costo { get; set; }

    public virtual Alumno? IdAlumnoNavigation { get; set; }

    public virtual Materium? IdMateriaNavigation { get; set; }
}
