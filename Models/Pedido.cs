using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRestaurante.Models
{
    public class Pedido
    {
        [Display(Name = "Pedido")]
        public int PedidoID { get; set; }
        [Display(Name = "Clientes")]
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }
        [Display(Name = "Empleados")]
        public int EmpleadoID { get; set; }
        public Empleado Empleado { get; set; }
        [Display(Name = "Mesa")]
        public int MesaID { get; set; }
        public Mesa Mesa { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public string Domicilio { get; set; }

    }
}
