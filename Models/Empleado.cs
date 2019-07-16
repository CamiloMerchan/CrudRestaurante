using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRestaurante.Models
{
    public class Empleado
    {
        [Display(Name = "Empleado")]
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        [Display(Name = "Cargo")]
        public int CargoID { get; set; }
        public Cargo Cargo { get; set; }

    }
}
