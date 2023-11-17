using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using proyecto_ecommerce_deportivo_net.Models;
using proyecto_ecommerce_deportivo_net.Models.Entity;

namespace proyecto_ecommerce_deportivo_net.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Producto> Producto  {get; set;}
    public DbSet<Proforma> DataCarrito { get; set; }

    public DbSet<Contacto> DataContactos { get; set; }

    /* agregado estas 3 tablas */
     public DbSet<Pago> DataPago { get; set; }

    public DbSet<Pedido> DataPedido { get; set; }

    public DbSet<DetallePedido> DataDetallePedido { get; set; }



    /* EN AQUI SE CREA Y SE CONECTA NUESTRA APLICACION CON LA BASE DE DATOS POSGRESS QUE ESTA EN LA NUBE USANDO RENDER */
}
