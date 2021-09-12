using Microsoft.EntityFrameworkCore;
using PrimerRegistroCompletoBlazor.DAL;
using PrimerRegistroCompletoBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrimerRegistroCompletoBlazor.BLL
{
    public class EstudiantesBLL
    {
        public static bool Existe(int id)
        {
            var contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Estudiantes.Any(e => e.EstudianteId == id);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
        /// <summary>
        /// Permite insertar una entidad en la base de datos
        /// </summary>
        /// <param name="estudiante">La entidad que se desea guardar</param>
        public static bool Insertar(Estudiantes estudiante)
        {
            Contexto contexto = new Contexto();
            bool insertado = false;

            try
            {
                contexto.Estudiantes.Add(estudiante);
                insertado = contexto.SaveChanges() > 0;
               
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return insertado;
        }

        /// <summary>
        /// Permite insertar una entidad en la base de datos
        /// </summary>
        /// <param name="estudiante">La entidad que se desea guardar</param>
        public static bool Modificar(Estudiantes estudiante)
        {
            bool paso = false;
            var contexto = new Contexto();

            try
            {
                contexto.Entry(estudiante).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        /// <summary>
        /// Permite insertar una entidad en la base de datos
        /// </summary>
        /// <param name="Estudiante">La entidad que se desea guardar</param>
        public static bool Guardar(Estudiantes Estudiante)
        {
            if (!Existe(Estudiante.EstudianteId))
                return Insertar(Estudiante);
            else
                return Modificar(Estudiante);
        }

        /// <summary>
        /// Permite eliminar una entidad de la base de datos
        /// </summary>
        /// <param name="id">El Id de la entidad que se desea eliminar</param>
        public static bool Eliminar(int id)
        {
            bool paso = false;
            var contexto = new Contexto();

            try
            {
                var estudiante = contexto.Estudiantes.Find(id);

                if(estudiante != null)
                {
                    contexto.Estudiantes.Remove(estudiante);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        /// <summary>
        /// Permite buscar una entidad en la base de datos
        /// </summary>
        /// <param name="id">El Id de la entidad que se desea buscar</param>
        public static Estudiantes Buscar(int id)
        {
            var contexto = new Contexto();
            Estudiantes estudiantes;

            try
            {
                estudiantes = contexto.Estudiantes.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return estudiantes;
        }

        public static List<Estudiantes> GetList(Expression<Func<Estudiantes, bool>> criterio)
        {
            List<Estudiantes> lista = new List<Estudiantes>();
            var contexto = new Contexto();

            try
            {
                lista = contexto.Estudiantes.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        public static List<Estudiantes> GetEstudiantes()
        {
            List<Estudiantes> lista = new List<Estudiantes>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Estudiantes.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

    }
}
