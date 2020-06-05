using Microsoft.EntityFrameworkCore;
using PrestamosWPF.DAL;
using PrestamosWPF.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PrestamosWPF.BLL
{
    class PrestamosBLL
    {
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //buscar la entidad que se desea eliminar
                var Prestamo = contexto.Prestamos.Find(id);
                if (Prestamo != null)
                {
                    contexto.Prestamos.Remove(Prestamo);//remover la entidad mas las que enel agrego
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
        public static Prestamos Buscar(int Id)
        {
            Contexto contexto = new Contexto();
            Prestamos Prestamo;

            try
            {
                Prestamo = contexto.Prestamos.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
            contexto.Dispose();
            return Prestamo;


        }
        public static bool Guardar(Prestamos Prestamo)
        {
            if (!Existe(Prestamo.PrestamoId))//si no existe insertamos
                return Insertar(Prestamo);
            else
                return Modificar(Prestamo);
        }
        public static bool Modificar(Prestamos Prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(Prestamo).State = EntityState.Modified;
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
        public static bool Insertar(Prestamos Prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //ana te cuento un c=secreto
                contexto.Prestamos.Add(Prestamo);
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


        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> expresion)
        {
            Contexto contexto = new Contexto();
            List<Prestamos> lista = new List<Prestamos>();
            try
            {
                lista = contexto.Prestamos.Where(expresion).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            contexto.Dispose();
            return lista;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Prestamos
                .Any(e => e.PrestamoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado; //si
        }
    }
}
