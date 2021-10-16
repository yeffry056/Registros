using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registros.Entidades
{
    public class Roles
    {
        [Key]
        public int RolId { get; set; }
        public DateTime FechaCreacion{ get; set; } = DateTime.Now;
        public string Descripcion { get; set; }
        public string Activo { get; set; }

        [ForeignKey("RolId")]
        public virtual List<RolesDetalles> Detalle { get; set; } = new List<RolesDetalles>();
    }
}
