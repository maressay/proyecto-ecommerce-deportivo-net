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
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace proyecto_ecommerce_deportivo_net.Controllers
{
    public class NoClienteController : Controller
    {
        private readonly ILogger<NoClienteController> _logger;
        private ApplicationDbContext _context;

        /* para el cliente o administrador iniciado */

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;
        public NoClienteController(ILogger<NoClienteController> logger, ApplicationDbContext context,
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _context = context;

            /* variables para el objeto iniciado */
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Catalogo()
        {
            var productos = from o in _context.Producto select o;
            return View(productos.ToList());
        }

        public async Task<IActionResult> DetalleProducto(int? id)
        {
            Producto objProduct = await _context.Producto.FindAsync(id);
            if (objProduct == null)
            {
                return NotFound();
            }
            return View(objProduct);
        }

        [HttpPost] // Asegúrate de que es un método POST
        public async Task<IActionResult> AddCarrito(int id, int cantidad)
        {
            var userID = _userManager.GetUserName(User); //sesion

            if (userID == null)
            {
                // no se ha logueado
                ViewData["Message"] = "Por favor debe loguearse antes de agregar un producto";
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                // ya está logueado
                var producto = await _context.Producto.FindAsync(id);

                // Buscar una proforma existente para el usuario y producto
                var proformaExistente = await _context.DataCarrito
                    .Where(p => p.UserID == userID && p.Producto.id == id)
                    .FirstOrDefaultAsync();

                if (proformaExistente != null)
                {
                    // Si existe, actualizar la cantidad
                    proformaExistente.Cantidad = cantidad;
                }
                else
                {
                    // Si no existe, crear una nueva proforma
                    Proforma proforma = new Proforma
                    {
                        Producto = producto,
                        Precio = producto.Precio,
                        Cantidad = cantidad, // Usa la cantidad pasada desde el formulario
                        UserID = userID
                    };
                    _context.Add(proforma);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Carrito");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}