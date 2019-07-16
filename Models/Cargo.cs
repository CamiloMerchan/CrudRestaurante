using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRestaurante.Models
{
    public class Cargo
    {
        [Display(Name = "Cargo")]
        public int CargoID { get; set; }

        public string Nombre { get; set; }
    }
}
