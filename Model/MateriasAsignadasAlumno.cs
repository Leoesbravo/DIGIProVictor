using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MateriasAsignadasAlumno
    {
        public int IdAlumnoMateria { get; set; }
        public Alumno Alumno { get; set; }
        public Materia Materia { get; set; }
        public List<object>? AlumnosMaterias { get; set; }
    }
}
