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
            Contexto contexto = new Contexto();
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
        public static bool Guardar(Estudiantes estudiante)
        {
            if (!Existe(estudiante.EstudianteId))
                return Insertar(estudiante);
            else
                return Modificar(estudiante);
        }

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
