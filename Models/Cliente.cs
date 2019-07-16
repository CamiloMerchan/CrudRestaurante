using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRestaurante.Models
{
    public class Cliente
    {
        [Display(Name = "Cliente")]
        public int ClienteID { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
       
    }
}
