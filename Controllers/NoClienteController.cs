using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proyecto_ecommerce_deportivo_net.Data;

namespace proyecto_ecommerce_deportivo_net.Controllers
{
    public class NoClienteController : Controller
    {
        private readonly ILogger<NoClienteController> _logger;
        private ApplicationDbContext _context;

        public NoClienteController(ILogger<NoClienteController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Catalogo()
        {
            var catalogo = _context.Producto.ToList();
            return View("Catalogo", catalogo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

    }
}