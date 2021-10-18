using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registros.Entidades
{
    public class RolesDetalles
    {
        [Key]
        public int Id { get; set; }
        public int RolId { get; set; }
        public int PermisoId { get; set; }
        public string EsAsignado { get; set; }
        public string Descripcion { get; set; }
        public int VecesAsignad { get; set; }

        public RolesDetalles(int RolId, int PermisoId, string EsAsignado, string Descripcion)
        {
            Id = 0;
            this.RolId = RolId;
            this.PermisoId = PermisoId;
            this.EsAsignado = EsAsignado;
            this.Descripcion = Descripcion;
           


        }
        
    }
}
