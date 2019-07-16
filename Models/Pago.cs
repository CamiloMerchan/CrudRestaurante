using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRestaurante.Models
{
    public class Pago
    {
        [Display(Name = "Pago")]
        public int PagoID { get; set; }
        [Display(Name = "Empleado")]
        public int EmpleadoID { get; set; }
        public Empleado Empleado { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
        public int Valor { get; set; }
        public string Descripcion { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }

    }
}
