using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proyecto_ecommerce_deportivo_net.Data;
using proyecto_ecommerce_deportivo_net.Models;
using proyecto_ecommerce_deportivo_net.Models.Entity;

using Microsoft.AspNetCore.Identity;

namespace proyecto_ecommerce_deportivo_net.Controllers {
    public class NoClienteController : Controller {
        private readonly ILogger<NoClienteController> _logger;
        private ApplicationDbContext _context;

        /* para el cliente o administrador iniciado */

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;
        public NoClienteController(ILogger<NoClienteController> logger, ApplicationDbContext context,
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager) {
            _logger = logger;
            _context = context;

            /* variables para el objeto iniciado */
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Catalogo() {
            var productos = from o in _context.Producto  select o;
            return View(productos.ToList());
        }

        public async Task<IActionResult> DetalleProducto(int? id){
            Producto objProduct = await _context.Producto.FindAsync(id);
            if(objProduct == null){
                return NotFound();
            }
            return View(objProduct);
        }

        public async Task<IActionResult> AddCarrito(int? id){
            var userID = _userManager.GetUserName(User); //sesion

            if(userID == null){
                // no se ha logueado
                ViewData["Message"] = "Por favor debe loguearse antes de agregar un producto";
                //List<Producto> productos = new List<Producto>();
                //return  View("Catalogo",productos);
                return View("~/Views/Home/Index.cshtml");
            } else {
                // ya esta logueado
                var producto = await _context.Producto.FindAsync(id);

                Proforma proforma = new Proforma();
                proforma.Producto = producto;
                proforma.Precio = producto.Precio; //precio del producto en ese momento
                proforma.Cantidad = 1;
                proforma.UserID = userID;
                _context.Add(proforma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Catalogo));
            }

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View("Error!");
        }
    }
}