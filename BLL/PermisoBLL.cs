using Microsoft.EntityFrameworkCore;
using Registros.DAL;
using Registros.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Registros.BLL
{
    public class PermisoBLL
    {
        public static Permisos Buscar(int id)
        {
            Permisos permiso = new Permisos();
            Contexto contexto = new Contexto();


            try
            {
                permiso = contexto.Permisos.Include(x => x.Detalle)
                    .Where(x => x.PermisoId == id)
                    .SingleOrDefault();
                //roles = contexto.Roles.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return permiso;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Permisos.Any(e => e.PermisoId == id);

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

        public static bool Insertar(Permisos permiso)
        {

            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                if (contexto.Permisos.Add(permiso) != null)
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
        private static bool Modificar(Permisos permiso)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {

                //busca la entidad en la base de datos y la elimina
                contexto.Database.ExecuteSqlRaw($"Delete FROM RolesDetalles Where PermisoId={permiso.PermisoId}");
                foreach (var item in permiso.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(permiso).State = EntityState.Modified;
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
        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                var permiso = contexto.Permisos.Find(id);
                if (permiso != null)
                {
                    contexto.Permisos.Remove(permiso);
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
        public static bool Guardar(Permisos permiso)
        {

            //  Contexto contexto = new Contexto();
            //  if (!Utilidades.Verificar(roles))
            //  {
            if (!Existe(permiso.PermisoId))
                return Insertar(permiso);
            else
                return Modificar(permiso);
            ///  }
            //  else
            //      MessageBox.Show("Este rol ya existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            //  return false;
        }

        public static List<Permisos> GetList(Expression<Func<Permisos, bool>> criterio)
        {
            List<Permisos> lista = new List<Permisos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Permisos.Where(criterio).ToList();
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
