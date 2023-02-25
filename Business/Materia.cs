using Model;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class Materia
    {
        public static Result InsertMateria(Model.Materia materia)
        {
            Result result = new Result();
            try
            {
                using (DigiProPruebaTecnicaContext context = new DigiProPruebaTecnicaContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"InsertMateria '{materia.Nombre}', '{materia.Costo}'");
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
        public static Result UpdateMateria(Model.Materia materia)
        {
            Result result = new Result();
            try
            {
                using (DigiProPruebaTecnicaContext context = new DigiProPruebaTecnicaContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UpdateMateria {materia.IdMateria},  '{materia.Nombre}', '{materia.Costo}'");

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
        public static Result DeleteMateria(Model.Materia materia)
        {
            Result result = new Result();

            try
            {
                using (DigiProPruebaTecnicaContext context = new DigiProPruebaTecnicaContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"DeleteMateria {materia.IdMateria}");
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
        public static Result GetMaterias()
        {
            Result result = new Result();
            try
            {
                using (DigiProPruebaTecnicaContext context = new DigiProPruebaTecnicaContext())
                {
                    var query = context.Materia.FromSqlRaw($"GetMaterias").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {

                            Model.Materia materia = new Model.Materia();
                            materia.IdMateria = obj.IdMateria;
                            materia.Nombre = obj.Nombre;
                            materia.Costo = obj.Costo;

                            result.Objects.Add(materia);
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
        public static Result GetMateria(int IdMateria)
        {
            Result result = new Result();
            try
            {
                using (DigiProPruebaTecnicaContext context = new DigiProPruebaTecnicaContext())
                {

                    var query = context.Materia.FromSqlRaw($"GetMateria {IdMateria}").AsEnumerable().FirstOrDefault();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        Model.Materia materia = new Model.Materia();

                        materia.IdMateria = query.IdMateria;
                        materia.Nombre = query.Nombre;
                        materia.Costo = query.Costo;

                        result.Object = materia;

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
    }
}

