using Microsoft.EntityFrameworkCore;
using Registros.DAL;
using Registros.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Registros.BLL
{
    public class RolesBLL
    {
        public static Roles Buscar(int id)
        {
            Roles roles = new Roles();
            Contexto contexto = new Contexto();
            

            try
            {
                roles = contexto.Roles.Include(x => x.Detalle)
                    .Where(x => x.RolId == id)
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
            return roles;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Roles.Any(e => e.RolId == id);

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

        public static bool Insertar(Roles roles)
        {

            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                if (contexto.Roles.Add(roles) != null)
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
        private static bool Modificar(Roles roles)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {

                //busca la entidad en la base de datos y la elimina
                contexto.Database.ExecuteSqlRaw($"Delete FROM RolesDetalles Where RolId={roles.RolId}");
                foreach (var item in roles.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(roles).State = EntityState.Modified;
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
                var roles = contexto.Roles.Find(id);
                if(roles != null)
                {
                    contexto.Roles.Remove(roles);
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
        public static bool Guardar(Roles roles)
        {
            
          //  Contexto contexto = new Contexto();
          //  if (!Utilidades.Verificar(roles))
          //  {
            if (!Existe(roles.RolId))
                return Insertar(roles);
            else
                return Modificar(roles);
          ///  }
          //  else
          //      MessageBox.Show("Este rol ya existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
          //  return false;
        }
        
        public static List<Roles> GetList(Expression<Func<Roles, bool>> criterio)
        {
            List<Roles> lista = new List<Roles>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Roles.Where(criterio).ToList();
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
