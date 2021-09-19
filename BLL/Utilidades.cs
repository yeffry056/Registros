using Registros.DAL;
using Registros.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Registros.BLL
{
    public class Utilidades
    {
        public static bool Verificar(Roles roles)
        {
            Contexto contexto = new Contexto();
            
            bool paso = false;

            try
            {
                
                paso = contexto.Roles.Any(e => e.Descripcion == roles.Descripcion);
                
                    
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
    }
}
