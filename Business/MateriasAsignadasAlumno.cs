using Model;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class MateriasAsignadasAlumno
    {
        public static Result AsignarMaterias(Model.MateriasAsignadasAlumno alumnoMateria)
        {
            Result result = new Result();
            try
            {
                using (DigiProPruebaTecnicaContext context = new DigiProPruebaTecnicaContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"AsignarMaterias '{alumnoMateria.Alumno.IdAlumno}', {alumnoMateria.Materia.IdMateria}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = true;
                result.Ex = ex;
            }
            return (result);
        }
        public static Result GetMateriasAsignadas(int IdAlumno)
        {
            Result result = new Result();
            try
            {
                using (DigiProPruebaTecnicaContext context = new DigiProPruebaTecnicaContext())
                {
                    var query = context.MateriasAsignadasAlumnos.FromSqlRaw($"GetMateriasAsignadas {IdAlumno}").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            Model.MateriasAsignadasAlumno alumnomateria = new Model.MateriasAsignadasAlumno();
                            alumnomateria.IdAlumnoMateria = obj.IdAlumnoMateria;

                            alumnomateria.Alumno = new Model.Alumno();
                            alumnomateria.Alumno.IdAlumno = obj.IdAlumno.Value;

                            alumnomateria.Materia = new Model.Materia();
                            alumnomateria.Materia.IdMateria = obj.IdMateria.Value;
                            alumnomateria.Materia.Nombre = obj.NombreMateria;
                            alumnomateria.Materia.Costo = obj.Costo;


                            result.Objects.Add(alumnomateria);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
        public static Result EliminarMateriaAsignada (int IdMateria, int IdAlumno)
        {
            Result result = new Result();

            try
            {
                using (DigiProPruebaTecnicaContext context = new DigiProPruebaTecnicaContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EliminarMateriaAsignada {IdMateria}, {IdAlumno}");
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el registro";
                    }

                    result.Correct = true;
                }
            }
            catch (Exception Ex)
            {
                result.Ex = Ex;
                result.ErrorMessage = "Ocurrio un Error" + result.Ex.Message;
                throw;
            }

            return result;
        }
        public static Result GetMateriasNoAsignadas(int IdAlumno)
        {
            Result result = new Result();
            try
            {
                using (DigiProPruebaTecnicaContext context = new DigiProPruebaTecnicaContext())
                {
                    var query = context.Materia.FromSqlRaw($"GetMateriasNoAsignadas {IdAlumno}").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            Model.MateriasAsignadasAlumno alumnomateria = new Model.MateriasAsignadasAlumno();
                            //alumnomateria.IdAlumnoMateria = obj.IdAlumnoMateria;

                            alumnomateria.Alumno = new Model.Alumno();
                            // alumnomateria.Alumno.IdAlumno = obj.IdAlumno;

                            alumnomateria.Materia = new Model.Materia();
                            alumnomateria.Materia.IdMateria = obj.IdMateria;
                            alumnomateria.Materia.Nombre = obj.Nombre;
                            alumnomateria.Materia.Costo = obj.Costo;


                            result.Objects.Add(alumnomateria);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
    }
}
