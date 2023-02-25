using Model;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class Alumno
    {
        public static Result UpdateAlumno(Model.Alumno alumno)
        {
            Result result = new Result();
            try
            {
                using (DigiProPruebaTecnicaContext context = new DigiProPruebaTecnicaContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UpdateAlumno {alumno.IdAlumno},  '{alumno.Nombre}', '{alumno.ApellidoPaterno}', '{alumno.ApellidoMaterno}', '{alumno.Imagen}'");

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
        public static Result DeleteAlumno(Model.Alumno alumno)
        {
            Result result = new Result();

            try
            {
                using (DigiProPruebaTecnicaContext context = new DigiProPruebaTecnicaContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"DeleteAlumno {alumno.IdAlumno}");
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
        public static Result GetAlumnos()
        {
            Result result = new Result();
            try
            {
                using (DigiProPruebaTecnicaContext context = new DigiProPruebaTecnicaContext())
                {
                    var query = context.Alumnos.FromSqlRaw($"GetAlumnos").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            Model.Alumno alumno = new Model.Alumno();
                            alumno.IdAlumno = obj.IdAlumno;
                            alumno.Nombre = obj.Nombre;
                            alumno.ApellidoPaterno = obj.Apaterno;
                            alumno.ApellidoMaterno = obj.Amaterno;
                            alumno.Imagen = obj.Imagen;

                            result.Objects.Add(alumno);
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
        public static Result GetAlumno(int IdAlumno)
        {
            Result result = new Result();
            try
            {
                using (DigiProPruebaTecnicaContext context = new DigiProPruebaTecnicaContext())
                {

                    var query = context.Alumnos.FromSqlRaw($"GetAlumno {IdAlumno}").AsEnumerable().FirstOrDefault();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        Model.Alumno alumno = new Model.Alumno();

                        alumno.IdAlumno = query.IdAlumno;
                        alumno.Nombre = query.Nombre;
                        alumno.ApellidoPaterno = query.Apaterno;
                        alumno.ApellidoMaterno = query.Amaterno;
                        alumno.Imagen = query.Imagen;

                        result.Object = alumno;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Usuario";
                    }
                }

            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static Result InsertAlumno(Model.Alumno alumno)
        {
            Result result = new Result();
            try
            {
                using (DigiProPruebaTecnicaContext context = new DigiProPruebaTecnicaContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"InsertAlumno '{alumno.Nombre}',  '{alumno.ApellidoPaterno}', '{alumno.ApellidoMaterno}',  '{alumno.Imagen}'");
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
    }
}
