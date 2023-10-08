using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto_ecommerce_deportivo_net.Models.Entity
{
    public class PedidoViewModel
    {
        public int ID { get; set; }
        public string? Status { get; set; }
        public List<DetallePedidoViewModel> Items { get; set; }
        public double Total { get; set; }
    }
}