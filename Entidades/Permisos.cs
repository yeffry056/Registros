﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registros.Entidades
{
    public class Permisos
    {
        [Key]
        public int PermisoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcionp { get; set; }
        public int VecesAsignado { get; set; }

        [ForeignKey("PermisoId")]
        public virtual List<RolesDetalles> Detalle { get; set; } = new List<RolesDetalles>();

    }
}
