using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registros.Entidades
{
    public class Roles
    {
        [Key]
        public int RolID { get; set; }
        public DateTime FechaCreacion{ get; set; } = DateTime.Now;
        public string Descripcion { get; set; }


    }
}
