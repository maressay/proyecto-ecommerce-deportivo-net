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
using Microsoft.EntityFrameworkCore;

namespace proyecto_ecommerce_deportivo_net.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ILogger<CarritoController> _logger;

        private ApplicationDbContext _context;

        /* para el cliente o administrador iniciado */

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;
        public CarritoController(ILogger<CarritoController> logger, ApplicationDbContext context,
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;


            _context = context;

            /* variables para el objeto iniciado */
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var userID = _userManager.GetUserName(User);
            var itemsEnCarrito = await _context.DataCarrito
                .Where(p => p.UserID == userID)
                .Include(p => p.Producto)
                .ToListAsync();

            double subtotal = itemsEnCarrito.Sum(item => item.Precio * item.Cantidad);
            double descuento = CalcularDescuento(subtotal); // Define este método según tu lógica de descuento.
            double total = subtotal - descuento;

            var viewModel = new CarritoViewModel
            {
                Items = itemsEnCarrito,
                Subtotal = subtotal,
                Descuento = descuento,
                Total = total
            };

            return View(viewModel);
        }

        private double CalcularDescuento(double subtotal)
        {
            // Ejemplo: Descuento del 10%
            return subtotal * 0.10;
        }

        public async Task<IActionResult> QuitarDelCarrito(int id)
        {
            var item = await _context.DataCarrito.FindAsync(id);
            if (item != null)
            {
                _context.DataCarrito.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Carrito");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}