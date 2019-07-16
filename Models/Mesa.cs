using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRestaurante.Models
{
    public class Mesa
    {

        public int MesaID { get; set; }

        [Display(Name = "Capacidad Personas ")]
        public int NumeroPersonas { get; set; }

    }
}
