using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_ecommerce_deportivo_net.Models.Entity
{
    [Table("t_order")]
    public class Pedido
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID {get; set;}

        public string? UserID{ get; set; }

        public Double Total { get; set; }

        public Pago? pago { get; set; }

        public string? Status { get; set; }
    }
}