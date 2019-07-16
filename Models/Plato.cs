using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRestaurante.Models
{
    public class Plato
    {

        [Display(Name = "Plato")]
        public int PlatoID { get; set; }
        [Display(Name = "Plato")]
        public string NombrePlato { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }

    }
}
