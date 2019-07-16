using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRestaurante.Models
{
    public class DetallePedido
    { 
        [Display(Name = "Orden")]
        public int DetallePedidoID { get; set; }
        [Display(Name = "Platos")]
        public int PlatoID { get; set; }
        public Plato Plato { get; set; }
        [Display(Name = "Pedido")]
        public int PedidoID { get; set; }
        public Pedido Pedido { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }

    }
}
